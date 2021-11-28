using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using NPL.SMS.R2S.Training.Entities;
using NPL.SMS.R2S.Training.DAO;

namespace NPL.SMS.R2S.Training.Main
{
    /// <summary>
    /// Class SaleManagement
    /// </summary>
    class SaleManagement
    {
        /// <summary>
        /// const string
        /// </summary>
        private const string SELECT_CUSTOMER_ID = "1";
        private const string SELECT_ORDER_ID = "2";
        private const string SELECT_LINEITEMS = "3";
        private const string TOTAL_PRICE = "4";
        private const string INSERT_CUSTOMER = "5";
        private const string DELETE_CUSTOMER = "6";
        private const string UPDATE_CUSTOMER = "7";
        private const string ADD_ORDER = "8";
        private const string ADD_LINEITEM = "9";
        private const string UPDATE_ORDER_TOTAL = "10";
        private const string EXIT = "exit";


        /// <summary>
        /// Display menu
        /// </summary>
        private static void CreateMenu()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("1. Select Customer");
            Console.WriteLine("2. Select Order");
            Console.WriteLine("3. Select LineItem");
            Console.WriteLine("4. Total Price");
            Console.WriteLine("5. Insert Customer");
            Console.WriteLine("6. Delete Customer");
            Console.WriteLine("7. Update Customer");
            Console.WriteLine("8. Add Order");
            Console.WriteLine("9. Add LineItem");
            Console.WriteLine("10. Update Order Total");
            Console.WriteLine("11. Exit");
            Console.WriteLine("choice: ");
        }
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string option;
            do
            {
                CreateMenu();
                option = Console.ReadLine();

                switch (option)
                {
                    case SELECT_CUSTOMER_ID:
                        CustomerDAO customerDAO = new CustomerDAO();

                        try
                        {
                            foreach (Customer t in customerDAO.GetAllCustomer())
                            {
                                Console.WriteLine(t);
                            }
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case SELECT_ORDER_ID:
                        Order order = new Order();
                        OrderDAO orderDAO = new OrderDAO();

                        Console.WriteLine("Enter CustomerId: ");
                        order.CustomerId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            foreach (Order t in orderDAO.GetAllOrdersByCustomerId(order.CustomerId))
                            {
                                Console.WriteLine(t);
                            }
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case SELECT_LINEITEMS:
                        LineItem lineItem = new LineItem();
                        LineITemDAO lineITemDAO = new LineITemDAO();

                        Console.WriteLine("Enter orderId: ");
                        lineItem.OrderId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            foreach (LineItem t in lineITemDAO.GetAllItemsByOrderId(lineItem.OrderId))
                            {
                                Console.WriteLine(t);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case TOTAL_PRICE:
                        OrderDAO orderdao = new OrderDAO();
                        LineItem lineitem = new LineItem();

                        Console.WriteLine("Enter orderId: ");
                        lineitem.OrderId = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            Console.WriteLine("Total: {0}", orderdao.ComputeOrderTotal(lineitem.OrderId));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case INSERT_CUSTOMER:
                        Customer customer = new Customer();
                        customerDAO = new CustomerDAO();
                        Console.WriteLine("Enter customer name: ");
                        customer.CustomerName = Console.ReadLine();

                        try
                        {
                            if (customerDAO.AddCustomer(customer))
                                Console.WriteLine("Successfully!");
                            else    
                                Console.WriteLine("Unsuccessfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case DELETE_CUSTOMER:
                        customer = new Customer();
                        customerDAO = new CustomerDAO();

                        Console.WriteLine("Enter customer id: ");

                        try
                        {
                            customer.CustomerId = Convert.ToInt32(Console.ReadLine());

                            if (customerDAO.DeleteCustomer(customer.CustomerId))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Unsuccessfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case UPDATE_CUSTOMER:
                        customer = new Customer();
                        customerDAO = new CustomerDAO();

                        try
                        {
                            Console.WriteLine("Enter customer id: ");
                            customer.CustomerId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter customer name: ");
                            customer.CustomerName = Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        };

                        try
                        {
                            if (customerDAO.UpdateCustomer(customer))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Unsuccessfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case ADD_ORDER:
                        order = new Order();
                        orderDAO = new OrderDAO();
                        try
                        {
                            Console.WriteLine("Enter order Date: ");
                            order.OrderDate = Convert.ToDateTime(Console.ReadLine());

                            Console.WriteLine("Enter customer ID: ");
                            order.CustomerId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee ID: ");
                            order.EmployeeId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter total: ");
                            order.Total = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        };

                        try
                        {
                            if (orderDAO.AddOrder(order))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Unsuccessfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case ADD_LINEITEM:

                        lineItem = new LineItem();
                        lineITemDAO = new LineITemDAO();

                        try
                        {
                            Console.WriteLine("Enter order ID: ");
                            lineItem.OrderId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter product ID: ");
                            lineItem.ProductId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter quantity: ");
                            lineItem.Quantity = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Price: ");
                            lineItem.Price = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        };

                        try
                        {
                            if (lineITemDAO.AddLineItem(lineItem))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Unsuccessfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case UPDATE_ORDER_TOTAL:

                        order = new Order();
                        orderDAO = new OrderDAO();

                        try
                        {
                            Console.WriteLine("Enter order ID: ");
                            order.OrderId = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        };

                        try
                        {
                            if (orderDAO.UpdateOrderTotal(order.OrderId))
                                Console.WriteLine("Successfully!");
                            else
                                Console.WriteLine("Unsuccessfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            } while (!option.Equals(EXIT));
        }
    }
}
