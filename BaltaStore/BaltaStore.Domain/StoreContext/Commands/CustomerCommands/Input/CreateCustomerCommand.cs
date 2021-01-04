using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class CreateCustomerCommand : Notifiable
    {
        

        // Fail Fast Validation
        public string  FirtsName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                 .HasMinLen(FirtsName, 3, "FirstName", "O Nome Deve Conter pelo menos 3 caracteres")
                 .HasMaxLen(FirtsName, 40, "FirstName", "O Nome Deve Conter no maximo 40 caracteres")
                 .HasMinLen(LastName, 3, "LastName", "O sobrenome Deve Conter pelo menos 3 caracteres")
                 .HasMaxLen(LastName, 40, "LastName", "O sobrenome Deve Conter no maximo 40 caracteres")
                 .IsEmail(Email, "Address", "O E-mail é invalido")
                 .HasLen(Document,11, "Document","CpfInvalido")
                 );
            return Valid();
        }
    }
}
