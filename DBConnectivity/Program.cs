
using System.Data;
using System.Data.SqlClient;
namespace DBConnectivity;

public class Program
{

    //Connection Global
    public static string connectionString = "Data Source=DESKTOP-K75VUCD;Database=db_hr;Integrated Security=True;Connect Timeout=30;";

    public static SqlConnection connection;
    public static void Main(string[] args)
    {   //database connectivity
        connection = new SqlConnection(connectionString);

        menu();
    }
    static void menu()
    {
        Console.WriteLine("Pilih Menu");
        Console.WriteLine("1. Region");
        Console.WriteLine("2. Country");
        Console.WriteLine("3. Location");
        Console.WriteLine("4. Department");
        Console.WriteLine("5. Employee");
        Console.WriteLine("6. Job");
        Console.WriteLine("7. History");
        Console.WriteLine("8. LINQ");

        try
        {
            Console.Write("Menu: ");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (input)
            {
                case 1:
                    Console.Clear();
                    //get all region
                    List<Region> regions = Region.GetAllRegion();
                    foreach (Region region in regions)
                    {
                        Console.WriteLine("ID: " + region.Id + ", Name: " + region.Name);
                    }
                    Console.WriteLine();

                    Console.WriteLine("1. Get Region By ID");
                    Console.WriteLine("2. Insert New Region");
                    Console.WriteLine("3. Update Region");
                    Console.WriteLine("4. Delete Region");
                    Console.WriteLine("5. Exit");
                    Console.Write("Masukan pilihan: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            //get region by id
                            Console.Write("Masukan ID region: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            List<Region> regionsid = Region.GetRegionByID(id);
                            foreach (Region region in regionsid)
                            {
                                Console.WriteLine("ID: " + region.Id + ", Name: " + region.Name);
                            }
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 2:
                            //insert region name
                            Console.WriteLine("Insert");
                            Console.Write("Masukan nama region: ");
                            string nama = Console.ReadLine();
                            int isInsertSuccessful = Region.InsertRegion(nama);
                            if (isInsertSuccessful > 0)
                            {
                                Console.WriteLine("Data berhasil ditambahkan!");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Data gagal ditambahkan!");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 3:
                            //update region name
                            Console.Write("Masukan ID region: ");
                            int idReg = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Masukan nama region: ");
                            string namaReg = Console.ReadLine();
                            Region.UpdateRegion(idReg, namaReg);
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 4:
                            //delete region
                            Console.WriteLine("Masukkan ID Region yang akan dihapus: ");
                            int regionId = Convert.ToInt32(Console.ReadLine());
                            Region.DeleteRegion(regionId);
                            Console.WriteLine("Data Region berhasil dihapus.");
                            Console.ReadKey();

                            /*bool success = Region.DeleteRegionI(regionId, connectionString);

                            if (success)
                            {
                                Console.WriteLine("Data Region berhasil dihapus.");
                            }
                            else
                            {
                                Console.WriteLine("Gagal menghapus data Region.");
                            }*/
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 5:
                            Console.Clear();
                            menu();
                            break;
                        default:
                            Console.WriteLine("Pilihan salah");
                            break;

                    }
                    break;

                case 2:
                    Console.Clear();
                    //get all country
                    List<Countries> countries = Countries.GetAllCountry();
                    foreach (Countries country in countries)
                    {
                        Console.WriteLine("ID: " + country.Id + ", Name: " + country.Name + ", Region ID: " + country.RegionId);
                    }
                    Console.WriteLine();

                    Console.WriteLine("1. Get Country By ID");
                    Console.WriteLine("2. Insert New Country");
                    Console.WriteLine("3. Update Country");
                    Console.WriteLine("4. Delete Country");
                    Console.WriteLine("5. Exit");
                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    switch (choice2)
                    {
                        case 1:
                            //get country by id
                            Console.Write("Masukan ID country: ");
                            string id = Console.ReadLine();

                            List<Countries> countryid = Countries.GetCountryByID(id);
                            foreach (Countries country in countryid)
                            {
                                Console.WriteLine("ID: " + country.Id + ", Name: " + country.Name + ", Region ID: " + country.RegionId);
                            }
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 2:
                            //insert country
                            Console.WriteLine("Insert");
                            Console.Write("Masukan ID country: ");
                            string idcountry = Console.ReadLine();

                            Console.Write("Masukan nama country: ");
                            string nama = Console.ReadLine();

                            Console.Write("Masukan ID region: ");
                            int idreg = Convert.ToInt32(Console.ReadLine());

                            Countries.InsertCountry(idcountry, nama, idreg);
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 3:
                            //update country
                            Console.Write("Masukan ID Country yang dicari: ");
                            string updIDC = Console.ReadLine();

                            Console.Write("Masukan nama Country baru: ");
                            string updNameC = Console.ReadLine();

                            Console.Write("Masukan ID Region baru: ");
                            int updIDR = Convert.ToInt32(Console.ReadLine());

                            Countries.UpdateCountry(updIDC, updNameC, updIDR);

                            Console.ReadKey();
                            Console.Clear();
                            menu();

                            break;
                        case 4:
                            //delete country
                            Console.WriteLine("Masukkan ID Region yang akan dihapus: ");
                            string countryId = Console.ReadLine();

                            Countries.DeleteCountry(countryId);
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 5:
                            Console.Clear();
                            menu();
                            break;
                        default:
                            Console.WriteLine("Pilihan salah");
                            break;
                    }
                    break;
                case 3:
                    Console.Clear();
                    //get all locations
                    List<Locations> locations = Locations.GetAllLocation();
                    foreach (Locations location in locations)
                    {
                        Console.WriteLine("ID: " + location.Id + ", Street Address: " + location.StreetAdrs + ", Postal Code: " + location.Postal + ", City: " + location.City + ", State Province: " + location.State + ", Country ID: " + location.CtrID);
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    menu();
                    break;
                case 4:
                    Console.Clear();
                    //get all departments
                    List<Departments> departments = Departments.GetAllDepartment();
                    foreach (Departments department in departments)
                    {
                        Console.WriteLine("ID: " + department.Id + ", Name: " + department.Name + ", Location ID: " + department.LocationID + ", Manager ID: " + department.ManagerID);
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    menu();
                    break;
                case 5:
                    Console.Clear();
                    //get all employee
                    List<Employees> employees = Employees.GetAllEmployee();
                    foreach (Employees employee in employees)
                    {
                        Console.WriteLine("=======================================");
                        Console.WriteLine("ID: " + employee.Id);
                        Console.WriteLine("First Name: " + employee.firstName);
                        Console.WriteLine("Last Name: " + employee.lastName);
                        Console.WriteLine("Email: " + employee.email);
                        Console.WriteLine("Phone: " + employee.phone);
                        Console.WriteLine("Hire date: " + employee.hiredate);
                        Console.WriteLine("Salary: " + employee.salary);
                        Console.WriteLine("Comission: " + employee.comission);
                        Console.WriteLine("Manager ID: " + employee.ManagerID);
                        Console.WriteLine("Job ID: " + employee.JobID);
                        Console.WriteLine("Department ID: " + employee.DptID);
                        Console.WriteLine("=======================================");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    menu();
                    break;
                case 6:
                    Console.Clear();
                    //get all jobs
                    List<Jobs> jobs = Jobs.GetAllJob();
                    foreach (Jobs job in jobs)
                    {
                        Console.WriteLine("ID: " + job.Id + ", Title: " + job.title + ", min salary: " + job.minSalary + ", max salary: " + job.maxSalary);
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    menu();
                    break;
                case 7:
                    Console.Clear();
                    //get all histories
                    List<Histories> histories = Histories.GetAllHistory();
                    foreach (Histories history in histories)
                    {
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Employee ID: " + history.Id);
                        Console.WriteLine("Start Date: " + history.startDate);
                        Console.WriteLine("End Date: " + history.endDate);
                        Console.WriteLine("Department ID: " + history.dptID);
                        Console.WriteLine("Job ID: " + history.jobID);
                        Console.WriteLine("=======================================");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    menu();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Tugas latihan linq");
                    Console.WriteLine("1. Soal 1");
                    Console.WriteLine("2. Soal 2");
                    Console.Write("Pilih: ");
                    int pilihan = Convert.ToInt32(Console.ReadLine());
                    switch (pilihan)
                    {
                        case 1:
                            Console.Clear();
                            LINQ.Menu();
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                        case 2:
                            Console.Clear();
                            LINQ.Menu2();
                            Console.ReadKey();
                            Console.Clear();
                            menu();
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Pilihan salah");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Pilihan salah");
        }
    }
}

