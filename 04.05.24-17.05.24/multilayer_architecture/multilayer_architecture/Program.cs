using multilayer_architecture.Model;
using System;

namespace multilayer_architecture
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            var dataLayer = new DataLayer(context);
            var businessLayer = new BusinessLayer(dataLayer);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Seçim yapınız:");
                Console.WriteLine("1. Çalışan Ekle");
                Console.WriteLine("2. Çalışan Güncelle");
                Console.WriteLine("3. Çalışan Sil");
                Console.WriteLine("4. Tüm Çalışanları Listele");
                Console.WriteLine("5. Departman Ekle");
                Console.WriteLine("6. Departman Güncelle");
                Console.WriteLine("7. Departman Sil");
                Console.WriteLine("8. Tüm Departmanları Listele");
                Console.WriteLine("9. Çıkış");
                Console.Write("Seçiminiz: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Çalışan Adı: ");
                        string name = Console.ReadLine();
                        Console.Write("Çalışan Soyadı: ");
                        string lastname = Console.ReadLine();
                        Console.Write("Kimlik Kartı Numarası: ");
                        int card = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Departman ID: ");
                        int department = Convert.ToInt32(Console.ReadLine());
                        businessLayer.PostEmployee(name, lastname, card, department);
                        Console.WriteLine("Çalışan eklendi.");
                        break;
                    case 2:
                        Console.Write("Güncellenecek Çalışanın Kimlik Kartı Numarası: ");
                        int updateCard = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Yeni Çalışan Adı: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Yeni Çalışan Soyadı: ");
                        string updateLastname = Console.ReadLine();
                        businessLayer.UpdateEmployee(updateName, updateLastname, updateCard);
                        Console.WriteLine("Çalışan güncellendi.");
                        break;
                    case 3:
                        Console.Write("Silinecek Çalışanın Kimlik Kartı Numarası: ");
                        int deleteCard = Convert.ToInt32(Console.ReadLine());
                        businessLayer.DeleteEmployee(deleteCard);
                        Console.WriteLine("Çalışan silindi.");
                        break;
                    case 4:
                        var employees = businessLayer.GetAllEmployees();
                        foreach (var emp in employees)
                        {
                            Console.WriteLine($"ID: {emp.employee_id_DTO}, Ad: {emp.employee_name_DTO}, Soyad: {emp.employee_lastname_DTO}, Departman: {emp.department_DTO.department_name}");
                        }
                        break;
                    case 5:
                        Console.Write("Departman Adı: ");
                        string depName = Console.ReadLine();
                        Console.Write("Departman Personel Sayısı: ");
                        short depStaff = Convert.ToInt16(Console.ReadLine());
                        businessLayer.PostDepartment(depName, depStaff);
                        Console.WriteLine("Departman eklendi.");
                        break;
                    case 6:
                        Console.Write("Güncellenecek Departman Adı: ");
                        string updateDepName = Console.ReadLine();
                        Console.Write("Yeni Departman Adı: ");
                        string newDepName = Console.ReadLine();
                        Console.Write("Yeni Departman Personel Sayısı: ");
                        short newDepStaff = Convert.ToInt16(Console.ReadLine());
                        businessLayer.UpdateDepartment(updateDepName, newDepName, newDepStaff);
                        Console.WriteLine("Departman güncellendi.");
                        break;
                    case 7:
                        Console.Write("Silinecek Departman Adı: ");
                        string deleteDepName = Console.ReadLine();
                        businessLayer.DeleteDepartment(deleteDepName);
                        Console.WriteLine("Departman silindi.");
                        break;
                    case 8:
                        var departments = businessLayer.GetAllDepartments();
                        foreach (var dep in departments)
                        {
                            Console.WriteLine($"ID: {dep.department_id}, Ad: {dep.department_name}, Personel Sayısı: {dep.department_staffs}");
                        }
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                        break;
                }
            }
        }
    }
}
