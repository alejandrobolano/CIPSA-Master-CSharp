namespace CIPSA_CSharp_Module11.Building.Models
{
    public class Building
    {
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Area { get; set; }

        public Building()
        {
                
        }

        public Building(int floor, int room, int area)
        {
            Floor = floor;
            Room = room;
            Area = area;
        }
    }
}
