using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.DAL.Context
{
    public class DropCreateDBOnModelChanged : DropCreateDatabaseAlways<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            List<string> ExpositionName = new List<string> { "Cigar and world", "Space", "Brain", "Fluid or sphere", "Nut", "Give me a cake" };
            List<string> GuideNames = new List<string>() { "Kari Hensien", "Terry Adams", "Dan Park", "Peter Houston", "Lukas Keller", "Mathew Charles", "John Smith" };
            List<string> ExpositionTheme = new List<string> { "Philosophy", "Science", "Science", "Abstraction", "Rave", "Rave" };
            int time = 2;
            for (int i = 0; i < ExpositionName.Count; i++)
            {
                var exposition = new Exposition() { ExpositionName = ExpositionName[i], Theme = ExpositionTheme[i], TargetAudience = 16, Plane = "+_+", Price = 150 };
                var grafik = new Grafik()
                {
                   //Id = exposition.Id,
                   Exposition = exposition,
                   StartTime = new TimeSpan(6 + i + i, 0, 15),
                   EndTime = new TimeSpan(6 + i + i + time, 0, 15)
                };
                
                var excursionsSchedule = new ExcursionsSchedule() { Id = grafik.Id, Grafik = grafik };
                
                var guide = new Guide() { Name = GuideNames[i] };
                var excursion = new Excursion() { Guide = guide, StartTime = grafik.StartTime, Time = time,ExcursionsSchedule=excursionsSchedule,Id=excursionsSchedule.Id };
                guide.Excursions.Add(excursion);
                
                excursionsSchedule.Excursion = excursion;
                var customExcursion = new CustomExcursion() { Guide = guide, StartTime = grafik.StartTime, Time = time,ExcursionsSchedule=excursionsSchedule };
                guide.CustomExcursion.Add(customExcursion);
                
                for (int j = 0; j < 10; j++)
                {
                    var customer = new Customer { Name = "Tourist_" + j * (i + 1), Age = 20, CustomExcursions = customExcursion };
                    customExcursion.Customers.Add(customer);
                    context.Customer.Add(customer);
                }
                excursionsSchedule.CustomExcursions.Add(customExcursion);
                context.Exposition.Add(exposition);
                context.Grafik.Add(grafik);
                context.ExcursionsSchedules.Add(excursionsSchedule);
                context.Guide.Add(guide);
                context.Excursions.Add(excursion);
                context.CustomExcursions.Add(customExcursion);

            }
            context.SaveChanges(); ;

        }
    }
}
