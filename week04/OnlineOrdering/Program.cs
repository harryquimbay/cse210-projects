using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 - Customer in the USA
        Address address1 = new Address(
            "4406 Stanley Avenue",
            "Garden City",
            "New York",
            "USA"
        );

        Customer customer1 = new Customer(
            "Frank P. McGuire",
            address1
        );

        Product product1 = new Product(
            "Wireless Mouse",
            "WM-101",
            25.99,
            2
        );

        Product product2 = new Product(
            "Keyboard",
            "KB-205",
            45.50,
            1
        );

        Product product3 = new Product(
            "USB Cable",
            "USB-310",
            8.99,
            3
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // Order 2 - Customer outside the USA
        Address address2 = new Address(
            "Calle 80 #15-20",
            "Bogota",
            "Cundinamarca",
            "Colombia"
        );

        Customer customer2 = new Customer(
            "Camilo Quintero",
            address2
        );

        Product product4 = new Product(
            "Webcam",
            "WC-410",
            59.99,
            1
        );

        Product product5 = new Product(
            "Laptop Stand",
            "LS-520",
            32.50,
            2
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // Display Order #1
        Console.WriteLine("========== ORDER 1 ==========");
        Console.WriteLine();

        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalPrice():F2}");


        Console.WriteLine();
        Console.WriteLine("=============================");
        Console.WriteLine();


        // Display Order #2
        Console.WriteLine("========== ORDER 2 ==========");
        Console.WriteLine();

        Console.WriteLine("PACKING LABEL:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("SHIPPING LABEL:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine();
        Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalPrice():F2}");
    }
}