using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public string id { get; set; }
        public string type { get; set; }
        public Timeinstant TimeInstant { get; set; }
        public Humidity humidity { get; set; }
        public Temperatura temperatura { get; set; }
        public Mesh_Name mesh_name { get; set; }
        public Ground_Humidity ground_humidity { get; set; }
        public H h { get; set; }
        public Luminosity luminosity { get; set; }
        public Pressure pressure { get; set; }
        public Rain_Mm rain_mm { get; set; }
        public T t { get; set; }
        public Wind_Speed wind_speed { get; set; }
        public Temperature temperature { get; set; }
    }

    public class Timeinstant
    {
        public string type { get; set; }
        public DateTime value { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Metadata
    {
    }

    public class Humidity
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata1 metadata { get; set; }
    }

    public class Metadata1
    {
        public Timeinstant1 TimeInstant { get; set; }
    }

    public class Timeinstant1
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Temperatura
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata2 metadata { get; set; }
    }

    public class Metadata2
    {
    }

    public class Mesh_Name
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata3 metadata { get; set; }
    }

    public class Metadata3
    {
        public Timeinstant2 TimeInstant { get; set; }
    }

    public class Timeinstant2
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Ground_Humidity
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata4 metadata { get; set; }
    }

    public class Metadata4
    {
        public Timeinstant3 TimeInstant { get; set; }
    }

    public class Timeinstant3
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class H
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata5 metadata { get; set; }
    }

    public class Metadata5
    {
        public Timeinstant4 TimeInstant { get; set; }
    }

    public class Timeinstant4
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Luminosity
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata6 metadata { get; set; }
    }

    public class Metadata6
    {
        public Timeinstant5 TimeInstant { get; set; }
    }

    public class Timeinstant5
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Pressure
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata7 metadata { get; set; }
    }

    public class Metadata7
    {
        public Timeinstant6 TimeInstant { get; set; }
    }

    public class Timeinstant6
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Rain_Mm
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata8 metadata { get; set; }
    }

    public class Metadata8
    {
        public Timeinstant7 TimeInstant { get; set; }
    }

    public class Timeinstant7
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class T
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata9 metadata { get; set; }
    }

    public class Metadata9
    {
        public Timeinstant8 TimeInstant { get; set; }
    }

    public class Timeinstant8
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Wind_Speed
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata10 metadata { get; set; }
    }

    public class Metadata10
    {
        public Timeinstant9 TimeInstant { get; set; }
    }

    public class Timeinstant9
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Temperature
    {
        public string type { get; set; }
        public string value { get; set; }
        public Metadata11 metadata { get; set; }
    }

    public class Metadata11
    {
        public Timeinstant10 TimeInstant { get; set; }
    }

    public class Timeinstant10
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

}
