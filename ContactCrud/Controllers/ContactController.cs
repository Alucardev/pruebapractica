using ContactCrud.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Mvc;

namespace ContactCrud.Controllers
{
    public class ContactController : Controller
    {

        private static string connection = ConfigurationManager.ConnectionStrings["connString"].ToString();
        private static List<Contact> contacts = new List<Contact>();
     
        // GET: Contact
        public ActionResult Home()
        {

            contacts = new List<Contact>(); 

            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CONTACT", conn);
                cmd.CommandType = System.Data.CommandType.Text;
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contact newContact = new Contact();
                        newContact.IdContact = Convert.ToInt32(reader["IdContact"]);
                        newContact.Names = reader["Names"].ToString();
                        newContact.LastNames = reader["LastNames"].ToString();
                        newContact.Phone = reader["Phone"].ToString();
                        newContact.Email = reader["Email"].ToString();
                        contacts.Add(newContact);
                    }
                }
            }

            return View(contacts);
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(Contact contact) {

            using (SqlConnection conn = new SqlConnection(connection)) {

                SqlCommand cmd = new SqlCommand("sp_Register", conn);
                cmd.Parameters.AddWithValue("Names", contact.Names);
                cmd.Parameters.AddWithValue("LastNames", contact.LastNames);
                cmd.Parameters.AddWithValue("Phone", contact.Phone);
                cmd.Parameters.AddWithValue("Email", contact.Email);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return View();
        }



        [HttpPost]
        public ActionResult Edit(Contact contact)
        {

            using (SqlConnection conn = new SqlConnection(connection))
            {

                SqlCommand cmd = new SqlCommand("sp_Edit", conn);
                cmd.Parameters.AddWithValue("IdContact", contact.IdContact);
                cmd.Parameters.AddWithValue("Names", contact.Names);
                cmd.Parameters.AddWithValue("LastNames", contact.LastNames);
                cmd.Parameters.AddWithValue("Phone", contact.Phone);
                cmd.Parameters.AddWithValue("Email", contact.Email);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return View();
        }


        [HttpGet]
        public ActionResult Edit(int? idcontact)
        {
            if (idcontact == null)
                return RedirectToAction("start", "Contact");

            Contact contact = contacts.FirstOrDefault();
            Console.WriteLine(contact.LastNames.ToString());

            return View(contact);
        }


        [HttpGet]
        public ActionResult Delete(int? idcontact)
        {
            if (idcontact == null)
                return RedirectToAction("start", "Contact");


            Contact ocontacto = contacts.Where(c => c.IdContact == idcontact).FirstOrDefault();
            return View(ocontacto);
        }


        [HttpPost]
        public ActionResult Delete(string IdContact)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("sp_Delete", conn);
                cmd.Parameters.AddWithValue("IdContact", IdContact);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Home", "Contact");
        }

    }
}

