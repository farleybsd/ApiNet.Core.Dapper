using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.OutPuts;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    //responsavel pelo fluxo do programa
    public class CustomerHandler : Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAdressCommandcs>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {

            // Verificar se o Cpf ja existe na base

            //Verificar se o email ja existe na base

            //Criar os Vos
            var name = new Name(command.FirtsName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar a entidade
            var customer = new Customer(name,document,email,command.Phone);

            //Validar entidades e Vo
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            //Persistir o cliente

            //Enviar um E-mail de boas vindas

            //Retornar o resultado para tela

            return new CreateCustomerCommandResult(Guid.NewGuid(),name.ToString(),email.Address);
        }

        public ICommandResult Handle(AddAdressCommandcs command)
        {
            throw new NotImplementedException();
        }
    }
}
