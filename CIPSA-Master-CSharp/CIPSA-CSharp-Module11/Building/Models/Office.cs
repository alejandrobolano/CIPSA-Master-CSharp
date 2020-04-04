namespace CIPSA_CSharp_Module11.Building.Models
{
    public class Office : Building
    {
        public int Extinguisher { get; set; }
        public int Phone { get; set; }

        public Office()
        {
                
        }
        public Office(int floor, int room, int area, int extinguisher, int phone)
        {
            Floor = floor;
            Room = room;
            Area = area;
            Extinguisher = extinguisher;
            Phone = phone;
        }

        public override string ToString()
        {
            var space = " ";
            return "Plantas: " + Floor + space +
                   "Habitaciones: " + Room + space +
                   "Superficie: " + Area + space +
                   "Extintores: " + Extinguisher + space +
                   "Teléfonos: " + Phone;
        }
    }
}
