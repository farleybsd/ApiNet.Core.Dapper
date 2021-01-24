using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.OutPuts;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
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
        private readonly ICustomRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o Cpf ja existe na base
            if(_repository.checkDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso"); //return null;

            //Verificar se o email ja existe na base
            if(_repository.checkEmail(command.Email))
                AddNotification("Email", "Email já existe"); //return null;

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

            if (Invalid)
                return new CommandResult(
                    false,
                    "Por Favor, Corrija os campos abaixo",
                    Notifications
                    );

            //Persistir o cliente
            _repository.Save(customer);

            //Enviar um E-mail de boas vindas
            _emailService.Send(email.Address,"farley.t.i@hotmail.com","Bem Vindo","teste");

            //Retornar o resultado para tela
            return new CommandResult(true, "Bem Vindo ao Balta Store", new{
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            }); 
        }

        public ICommandResult Handle(AddAdressCommandcs command)
        {
            throw new NotImplementedException();
        }
    }
}
