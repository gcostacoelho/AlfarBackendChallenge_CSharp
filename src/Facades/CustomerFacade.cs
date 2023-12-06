using System.Text.RegularExpressions;


using AlfarBackendChallengeV2.src.Facades.Interfaces;
using AlfarBackendChallengeV2.src.Models.Customer;
using AlfarBackendChallengeV2.src.Models.Email;
using AlfarBackendChallengeV2.src.Services.Interfaces;
using AlfarBackendChallengeV2.src.Models.Utils;
using System.Net;

namespace AlfarBackendChallengeV2.src.Facades
{
    public class CustomerFacade : ICustomerFacade
    {
        private const string SUBJECT = "{0}, conta criada com sucesso";

        private readonly ICustomerService _customer;
        private readonly IMailKitService _mailKit;

        public CustomerFacade(ICustomerService customerService, IMailKitService mailKitService)
        {
            _customer = customerService;
            _mailKit = mailKitService;
        }

        public async Task<Customer> PostNewCustomerAndSendEmailAsync(Customer customer)
        {
            var emailValid = ValidEmail(customer.Email);

            if (!emailValid)
            {
                throw new ApiException("Email not valid", HttpStatusCode.BadRequest);
            }

            var customerInDB = await _customer.PostNewCustomer(customer);

            var emailMounted = MountEmail(customerInDB);

            _mailKit.SendEmail(emailMounted);

            return customerInDB;
        }

        private static Email MountEmail(Customer customerData)
        {
            var message = string.Format("Nome: {0}\nDocumento: {1}\nData de nascimento: {2}\nEmail: {3}\nTelefone: {4}\nEndereço: {5}",
                customerData.Name, customerData.Document, customerData.BirthdayDate, customerData.Email, customerData.Cellphone, customerData.Address
            );

            var emailBody = string.Format("Informações que foram cadastradas:\n\n{0}", message);

            return new Email()
            {
                To = customerData.Email,
                Subject = string.Format(SUBJECT, customerData.Name),
                Username = customerData.Name,
                Body = emailBody
            };
        }

        private static bool ValidEmail(string email)
        {
            return Regex.IsMatch(email, "[^@ \t\r\n]+@[^@ \t\r\n]+\\.[^@ \t\r\n]+");
        }
    }
}