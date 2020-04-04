namespace CIPSA_CSharp_Module11.Building.Models
{
    public class House : Building
    {
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }

        public House()
        {
                
        }
        public House(int floor, int room, int area, int bedroom, int bathroom)
        {
            Floor = floor;
            Room = room;
            Area = area;
            Bedroom = bedroom;
            Bathroom = bathroom;
        }

        public override string ToString()
        {
            var space = " ";
            return "Plantas: " + Floor + space +
                   "Habitaciones: " + Room + space +
                   "Superficie: " + Area + space +
                   "Dormitorio: " + Bedroom + space +
                   "Baños: " + Bathroom;
        }
    }
}
