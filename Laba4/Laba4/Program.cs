using Laba4.DataBase;
using Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<CarDealerDB>()
        .UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CarDealer;Integrated Security=True").Options;
        using (var context = new CarDealerDB(options))
        {

            Console.WriteLine("Введите сколько вы хотите добавить Брэндов");
            int number_of_marks = Convert.ToInt32(Console.ReadLine());
            string[] markNames = new string[number_of_marks];
            int number_of_models;
            string[] modelNames;
            for (int i = 0; i < number_of_marks; i++)
            {
                Console.WriteLine($"Введите название {i + 1} марки:");
                markNames[i] = Console.ReadLine();
                var mark = new Mark { mark_name = markNames[i] };
                context.Marks.Add(mark);
                Console.WriteLine("Введите сколько вы хотите добавить моделей");
                number_of_models = Convert.ToInt32(Console.ReadLine());
                modelNames = new string[number_of_models];
                for (int j = 0; j < number_of_models; j++)
                {
                    Console.WriteLine($"Введите название {j + 1} модели для марки машины {markNames[i]}:");
                    modelNames[j] = Console.ReadLine();
                    var model = new Model { model_name = modelNames[j], mark = mark };
                    context.models.Add(model);
                }
            }

            context.SaveChanges();

            
            Console.WriteLine("Добавленные значения Mark и Model:");
            foreach (var m in context.Marks)
            {
                Console.WriteLine($"Mark: {m.mark_name}");
                foreach (var mo in m.Models)
                {
                    Console.WriteLine($"Model: {mo.model_name}");
                }
            }
            Console.WriteLine("Теперь введите в какой таблице будете работать \n 1-Машины \n 2-Пользователи \n 3-Заказы \n 0-Выход");
            int choice_1 = -1;
            while (choice_1 != 0)
            {
                Console.WriteLine("Введите в какой таблице будете работать \n 1 - Машины \n 2 - Пользователи \n 3 - Заказы \n 0 - Выход");
                choice_1 = Convert.ToInt32(Console.ReadLine());
                switch (choice_1)
                {
                    case 0:
                        Console.WriteLine("До свидания!");
                        break;
                    case 1:
                        Console.WriteLine("Выберите что хотите сделать:\n 1 - Посмотреть на таблицу \n 2 - Добавить машину \n 3 - Удалить машину \n 4 - изменить машину \n 0 - Выход ");
                        int choice_car = Convert.ToInt32(Console.ReadLine());
                        switch (choice_car)
                        {
                            case 1:
                                foreach (var car in context.Cars)
                                {
                                    Console.WriteLine($"ID: {car.ID}");
                                    Console.WriteLine($"Model: {car.model.model_name}");
                                    Console.WriteLine($"Year: {car.year}");
                                    Console.WriteLine($"Body Type: {car.body_type}");
                                    Console.WriteLine($"Engine Volume: {car.engine_volume}");
                                    Console.WriteLine($"Mileage: {car.mileage}");
                                    Console.WriteLine($"Price: {car.price}");
                                    Console.WriteLine("---------------------------");
                                }
                                break;
                            case 2:
                                foreach (var m in context.Marks)
                                {
                                    Console.WriteLine($"Mark: {m.mark_name}");
                                    foreach (var mo in m.Models)
                                    {
                                        Console.WriteLine($"Model: {mo.Id} {mo.model_name}");
                                    }
                                }

                                Console.WriteLine($"Введите какой модели будет машина");
                                int modelId = Convert.ToInt32(Console.ReadLine());
                                var selectedModel = context.models.FirstOrDefault(m => m.Id == modelId);
                                if (selectedModel != null)
                                {
                                    Console.WriteLine("Введите год выпуска машины:");
                                    string year = Console.ReadLine();

                                    Console.WriteLine("Введите тип кузова машины:");
                                    string bodyType = Console.ReadLine();

                                    Console.WriteLine("Введите объем двигателя машины:");
                                    double engineVolume = Convert.ToDouble(Console.ReadLine());

                                    Console.WriteLine("Введите пробег машины:");
                                    double mileage = Convert.ToDouble(Console.ReadLine());

                                    Console.WriteLine("Введите цену машины:");
                                    double price = Convert.ToDouble(Console.ReadLine());
                                    var car = new Car
                                    {
                                        model_id = modelId,
                                        model = selectedModel,
                                        year = year,
                                        body_type = bodyType,
                                        engine_volume = engineVolume,
                                        mileage = mileage,
                                        price = price
                                    };

                                    context.Cars.Add(car);
                                    context.SaveChanges();
                                }
                                else
                                    Console.WriteLine("Такой модели нет");
                                break;
                            case 3:
                                Console.WriteLine("Введите ID машины, которую хотите удалить:");
                                int carId = Convert.ToInt32(Console.ReadLine());
                                var carToDelete = context.Cars.FirstOrDefault(c => c.ID == carId);
                                if (carToDelete != null)
                                {
                                    context.Cars.Remove(carToDelete);
                                    context.SaveChanges();
                                    Console.WriteLine("Машина успешно удалена.");
                                }
                                else
                                {
                                    Console.WriteLine("Машина с указанным ID не найдена.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Введите ID машины, которую хотите изменить:");
                                int carIdToUpdate = Convert.ToInt32(Console.ReadLine());
                                var carToUpdate = context.Cars.FirstOrDefault(c => c.ID == carIdToUpdate);
                                if (carToUpdate != null)
                                {

                                    Console.WriteLine("Введите новый пробег машины:");
                                    double newMileage = Convert.ToDouble(Console.ReadLine());
                                    carToUpdate.mileage = newMileage;

                                    Console.WriteLine("Введите новую цену машины:");
                                    double newPrice = Convert.ToDouble(Console.ReadLine());
                                    carToUpdate.price = newPrice;

                                    context.SaveChanges();
                                    Console.WriteLine("Машина успешно изменена.");
                                }
                                else
                                {
                                    Console.WriteLine("Машина с указанным ID не найдена.");
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Выберите что хотите сделать:\n 1-Посмотреть на таблицу \n 2-Добавить пользователя \n 3 - Удалить пользователя \n 4 - изменить пользователя \n 0 - Выход ");
                        int choice_customer = Convert.ToInt32(Console.ReadLine());
                        switch (choice_customer)
                        {
                            case 1:
                                foreach (var customer in context.Customers)
                                {
                                    Console.WriteLine($"ID: {customer.ID}");
                                    Console.WriteLine($"Имя: {customer.first_Name}");
                                    Console.WriteLine($"Фамилия: {customer.last_name}");
                                    Console.WriteLine($"Телефонный номер: {customer.Personalnumber.number}");

                                    Console.WriteLine("Список заказов:");
                                    if (customer.OrdersCustomer != null)
                                        foreach (var order in customer.OrdersCustomer)
                                        {
                                            Console.WriteLine($"Заказ ID: {order.Id}");
                                            Console.WriteLine($"Дата заказа: {order.date_of_order}");
                                            Console.WriteLine($"Машина ID: {order.car_id}");
                                            Console.WriteLine("---------------------------");
                                        }
                                    else
                                        Console.WriteLine("Заказы ещё не созданы");

                                    Console.WriteLine("---------------------------");

                                }
                                break;
                            case 2:
                                {
                                    Console.WriteLine("Введите имя пользователя:");
                                    string firstName = Console.ReadLine();

                                    Console.WriteLine("Введите фамилию пользователя:");
                                    string lastName = Console.ReadLine();

                                    Console.WriteLine("Введите телефонный номер пользователя:");
                                    string phoneNumber = Console.ReadLine();
                                    var firstPersonalNumber = context.Personalnumbers.FirstOrDefault();
                                    Guid personalNumberId;

                                    if (firstPersonalNumber != null)
                                    {
                                        personalNumberId = firstPersonalNumber.ID;
                                        context.Personalnumbers.Remove(firstPersonalNumber);
                                    }
                                    else
                                    {
                                        personalNumberId = Guid.NewGuid();
                                    }

                                    var personalNumber = new Personalnumber
                                    {
                                        ID = personalNumberId,
                                        number = phoneNumber
                                    };

                                    var customer = new Customer
                                    {
                                        first_Name = firstName,
                                        last_name = lastName,
                                        PersonalnumberId = personalNumberId,
                                        Personalnumber = personalNumber
                                    };

                                    context.Customers.Add(customer);
                                    context.Personalnumbers.Add(personalNumber);
                                    context.SaveChanges();

                                    Console.WriteLine("Пользователь успешно добавлен.");
                                }

                                break;
                            case 3:
                                Console.WriteLine("Введите ID пользователя, которого хотите удалить:");
                                int customerId = Convert.ToInt32(Console.ReadLine());
                                var customerToDelete = context.Customers.FirstOrDefault(c => c.ID == customerId);
                                if (customerToDelete != null)
                                {
                                    context.Customers.Remove(customerToDelete);
                                    context.SaveChanges();
                                    Console.WriteLine("Пользователь успешно удален.");
                                }
                                else
                                {
                                    Console.WriteLine("Пользователь с указанным ID не найден.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Введите ID пользователя, которого хотите изменить:");
                                int customerIdToUpdate = Convert.ToInt32(Console.ReadLine());
                                var customerToUpdate = context.Customers.FirstOrDefault(c => c.ID == customerIdToUpdate);
                                if (customerToUpdate != null)
                                {
                                    Console.WriteLine("Введите новое имя пользователя:");
                                    string newFirstName = Console.ReadLine();

                                    Console.WriteLine("Введите новую фамилию пользователя:");
                                    string newLastName = Console.ReadLine();

                                    Console.WriteLine("Введите новый телефонный номер пользователя:");
                                    string newPhoneNumber = Console.ReadLine();

                                    var personalNumberToUpdate = context.Personalnumbers.FirstOrDefault(p => p.ID == customerToUpdate.PersonalnumberId);
                                    if (personalNumberToUpdate != null)
                                    {
                                        personalNumberToUpdate.number = newPhoneNumber;
                                    }

                                    customerToUpdate.first_Name = newFirstName;
                                    customerToUpdate.last_name = newLastName;

                                    context.SaveChanges();
                                    Console.WriteLine("Пользователь успешно изменен.");
                                }
                                else
                                {
                                    Console.WriteLine("Пользователь с указанным ID не найден.");
                                }
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Выберите что хотите сделать:\n 1-Посмотреть на таблицу \n 2-Добавить Заказ \n 3 - Удалить заказ \n 4 - изменить заказ \n 0 - Выход ");
                        int choice_order = Convert.ToInt32(Console.ReadLine());
                        switch (choice_order)
                        {
                            case 1:

                                foreach (var order in context.Orders)
                                {
                                    Console.WriteLine($"ID: {order.Id}");
                                    Console.WriteLine("Список покупателей:");
                                    if (order.Customers != null)
                                        foreach (var customer in order.Customers)
                                        {
                                            Console.WriteLine($"ID: {customer.ID}");
                                            Console.WriteLine($"Имя: {customer.first_Name}");
                                            Console.WriteLine($"Фамилия: {customer.last_name}");
                                            Console.WriteLine($"Телефонный номер: {customer.Personalnumber.number}");
                                            Console.WriteLine("---------------------------");
                                        }
                                    Console.Write($"Дата создания заказа: {order.date_of_order}");
                                    Console.WriteLine("Список машин в заказе");
                                    if (order.Cars != null)
                                    {
                                        foreach (var car in order.Cars)
                                        {
                                            Console.WriteLine($"ID: {car.ID}");
                                            Console.WriteLine($"Model: {car.model.model_name}");
                                            Console.WriteLine($"Year: {car.year}");
                                            Console.WriteLine($"Body Type: {car.body_type}");
                                            Console.WriteLine($"Engine Volume: {car.engine_volume}");
                                            Console.WriteLine($"Mileage: {car.mileage}");
                                            Console.WriteLine($"Price: {car.price}");
                                            Console.WriteLine("---------------------------");
                                        }
                                    }
                                }
                                break;
                            case 2:
                                {
                                    Console.WriteLine("Введите ID покупателя:");
                                    int customerId = Convert.ToInt32(Console.ReadLine());
                                    var customer = context.Customers.FirstOrDefault(c => c.ID == customerId);
                                    if (customer != null)
                                    {
                                        Console.WriteLine("Введите ID машины:");
                                        int carId = Convert.ToInt32(Console.ReadLine());
                                        var car = context.Cars.FirstOrDefault(c => c.ID == carId);
                                        Console.WriteLine("Введите Дату создания заказа:");
                                        string date_of_order = Console.ReadLine();
                                        if (car != null)
                                        {
                                            var order = new Order
                                            {
                                                Customers = new List<Customer> { customer },
                                                Cars = new List<Car> { car },
                                                date_of_order = date_of_order
                                            };
                                            context.Orders.Add(order);
                                            context.SaveChanges();
                                            Console.WriteLine("Заказ успешно добавлен.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Машина с указанным ID не найдена.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Покупатель с указанным ID не найден.");
                                    }
                                    break;
                                }
                            case 3:
                                Console.WriteLine("Введите ID заказа, который хотите удалить:");
                                int orderIdToDelete = Convert.ToInt32(Console.ReadLine());
                                var orderToDelete = context.Orders.FirstOrDefault(o => o.Id == orderIdToDelete);
                                if (orderToDelete != null)
                                {
                                    context.Orders.Remove(orderToDelete);
                                    context.SaveChanges();
                                    Console.WriteLine("Заказ успешно удален.");
                                }
                                else
                                {
                                    Console.WriteLine("Заказ с указанным ID не найден.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("Введите ID заказа, который хотите изменить:");
                                int orderIdToUpdate = Convert.ToInt32(Console.ReadLine());
                                var orderToUpdate = context.Orders.FirstOrDefault(o => o.Id == orderIdToUpdate);
                                if (orderToUpdate != null)
                                {
                                    Console.WriteLine("Введите новый ID покупателя:");
                                    int newCustomerId = Convert.ToInt32(Console.ReadLine());
                                    var newCustomer = context.Customers.FirstOrDefault(c => c.ID == newCustomerId);
                                    if (newCustomer != null)
                                    {
                                        Console.WriteLine("Введите новый ID машины:");
                                        int newCarId = Convert.ToInt32(Console.ReadLine());
                                        var newCar = context.Cars.FirstOrDefault(c => c.ID == newCarId);
                                        if (newCar != null)
                                        {
                                            orderToUpdate.Customers.Clear();
                                            orderToUpdate.Customers.Add(newCustomer);
                                            orderToUpdate.Cars.Clear();
                                            orderToUpdate.Cars.Add(newCar);
                                            context.SaveChanges();
                                            Console.WriteLine("Заказ успешно изменен.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Машина с указанным ID не найдена.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Покупатель с указанным ID не найден.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Заказ с указанным ID не найден.");
                                }
                                break;
                        }
                        break;

                }
            }
        }
    }
}