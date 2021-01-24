using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Api.Controllers
{
    public class CustomerControle : Controller
    {
        private readonly ICustomRepository _repository;
        private readonly CustomerHandler _handlers;

        public CustomerControle(ICustomRepository repository,CustomerHandler handler)
        {
            _repository = repository;
            _handlers = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration =60)] // Cache da rota
        //[ResponseCache(Location =ResponseCacheLocation.Client,Duration = 60)] // Cache do lado do cliente
        //Evitar Coisas para fazer que cahe que muda com mt frequencia
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            

            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListQueryCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommand) _handlers.Handle(command);

            if (_handlers.Invalid)
                return BadRequest(_handlers.Notifications);

            return result;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirtsName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!" };
        }
    }
}
