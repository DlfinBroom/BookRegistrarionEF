using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrarionEF {
    class CustomerDB {
        public static List<Customer> GetCustomers() {

            BookRegContext context = new BookRegContext();
            List<Customer> allCustomers = context.Customer.ToList();

            return allCustomers;
        } 

        public static Customer AddCustomer(Customer cus) {

            BookRegContext context = new BookRegContext();

            context.Customer.Add(cus);
            context.SaveChanges();

            return cus;
        }

        public static void DeleteCustomer(Customer cus) {

            BookRegContext context = new BookRegContext();
            // Saying cus exists in the DB
            context.Customer.Attach(cus);
            // Removing cus from the DB
            context.Customer.Remove(cus);

            // Alternative
            // context.Entry(cus).State = EntityState.Deleted;

            context.SaveChanges();
        }

        public static Customer Update(Customer cus) {
            BookRegContext context = new BookRegContext();

            context.Entry(cus).State = EntityState.Modified;
            context.SaveChanges();

            return cus;
        }
    }
}