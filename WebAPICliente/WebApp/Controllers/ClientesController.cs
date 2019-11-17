using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Models.Domain;
using WebApp.Models.ViewModel;

namespace WebApp.Controllers
{
    [RoutePrefix("api/clientes")]//Roteamento para acessar a API
    public class ClientesController : ApiController
    {
        private ContextoBD db = new ContextoBD();

        //GET: api/Clientes
        [HttpGet]
        [Route("todos")]//api/clientes/todos
        public IQueryable<Cliente> GetClientes()
        {
            try
            {
                return db.Cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        [HttpGet]
        [Route("{id}")]//api/clientes/1
        public IHttpActionResult GetClientePorId(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        //POST: api/Clientes
        [ResponseType(typeof(ClienteViewModel))]
        [HttpPost]
        [Route("incluir")]//api/clientes/incluir
        public IHttpActionResult CadastrarCliente(ClienteViewModel clienteViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
        
                if (EmailExiste(clienteViewModel.Email, clienteViewModel))
                {
                    return Ok(new { Menssage = "E-mail informado já existe" });
                }
                Cliente cliente = new Cliente();
                cliente.Nome = clienteViewModel.Nome;
                cliente.Endereco = clienteViewModel.Endereco;
                cliente.Telefone = clienteViewModel.Telefone;     
                cliente.Email = clienteViewModel.Email;
                cliente.Cidade = clienteViewModel.Cidade;
                cliente.DataCadastro = DateTime.Now;
                cliente.Ativo = true;
                db.Cliente.Add(cliente);
                db.SaveChanges();                
               return Ok (new { Menssage = "Cadastro realizado com sucesso" });
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        //PUT: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        [HttpPut]
        [Route("alterar")]//api/clientes/alterar?id=1
        public IHttpActionResult AlterarCliente(int id, ClienteViewModel clienteViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != clienteViewModel.Id)
                {
                    return BadRequest();
                }
                Cliente _cliente = new Cliente();
                if (EmailExiste(clienteViewModel.Email, clienteViewModel))
                {
                    return Ok(new { Menssage = "E-mail informado já existe" });
                }

                var cliente = db.Cliente.First(c => c.Id == clienteViewModel.Id && c.Ativo == true);               
                cliente.Nome = clienteViewModel.Nome;
                cliente.Endereco = clienteViewModel.Endereco;
                cliente.Telefone = clienteViewModel.Telefone;
                cliente.Email = clienteViewModel.Email;
                cliente.Cidade = clienteViewModel.Cidade;

                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(new { Menssage = "Cadastro alterado com sucesso" });
            }
            catch (Exception ex)
            {
                //return StatusCode(HttpStatusCode.NotFound );
                throw new Exception(ex.Message + StatusCode(HttpStatusCode.NotFound));
            }     
           
        }
      
        /*=== Verifica se e-mail informado já existe, tela incluir e alterar ========*/
        private bool EmailExiste(string email, ClienteViewModel _clienteModel) {
            try
            {
                return db.Cliente.Count(c => c.Email == email && c.Id != _clienteModel.Id) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        [HttpDelete]
        [Route("remover")] //api/clientes/remover?id=1
        public IHttpActionResult RemoverCliente(int id)
        {
            try
            {
                Cliente cliente = db.Cliente.Find(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                db.Cliente.Remove(cliente);
                db.SaveChanges();

                return Ok(cliente);
            }
            catch (Exception ex)  
            {
                throw new Exception(ex.Message + StatusCode(HttpStatusCode.NotFound));
            }
        }

        /*========= Agora poderíamos realizar testes das operações CRUD usando o Postman ===============*/

        /*Atenção: Antes de concluir precisamos alterar o código do método Register no arquivo WebApiConfig na pasta App_Start para habilitar o CORS e também para forçar a resposta non formato JSON */

        /* Baixar o pacate Microsoft.AspNet.WebApi.Cors */

    }
}
