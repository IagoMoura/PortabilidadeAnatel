using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public static class Repository
    {
        private static List<Customer> customers { get; set; }


        public static List<Customer> GetCustomers()
        {
            if (Repository.customers == null || Repository.customers.Count == 0)
            {
                Repository.customers = new List<Customer>();
                Repository.customers.Add(new Customer()
                {
                    Cpf = "12345678910",
                    Name = "Maria",
                    Id = 1,
                    Account = new Account()
                    {
                        AccountNumber = "123",
                        Agency = "123",
                        Id = 1
                    },
                    Phone = "3523-3323",
                    FinanceStatus = true
                });

                Repository.customers.Add(new Customer()
                {
                    Cpf = "33322211110",
                    Name = "Joao",
                    Id = 2,
                    Account = new Account()
                    {
                        AccountNumber = "123",
                        Agency = "123",
                        Id = 2
                    },
                    Phone = "3323-3323",
                    FinanceStatus = false
                });

                Repository.customers.Add(new Customer()
                {
                    Cpf = "11122233310",
                    Name = "Joana",
                    Id = 3,
                    Account = new Account()
                    {
                        AccountNumber = "222",
                        Agency = "33",
                        Id = 3
                    },
                    Phone = "4323-3323",
                    FinanceStatus = true
                });
            }

            return customers;
        }

        public static bool UpdateCustomer(Customer customer)
        {
            Customer result = Repository.GetCustomers().FirstOrDefault(c => customer.Cpf == c.Cpf);
            if (result == null)
            {
                return false;
            }
            result.PortabilityDate = customer.PortabilityDate;
            return true;
        }

    }
}
