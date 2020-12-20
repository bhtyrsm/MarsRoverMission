using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverMission
{
    public class Program
    {
        static void Main(string[] args)
        {
            Rover rover = new Rover();

            try
            {
                Console.WriteLine("Enter the x-y boundaries like 0 0");

                var boundaries = Console.ReadLine();
                rover.setBoundaries(boundaries);


                Console.WriteLine("Enter the start position like 0 0 N ");

                var startPosition = Console.ReadLine();
                rover.ValidateAndSetStartPosition(startPosition);

                Console.WriteLine("Enter the Instructions");

                var instructions = Console.ReadLine();
                rover.Move(instructions);

                Console.WriteLine("OUTPUT :");
                Console.WriteLine(rover.Position_X + " " + rover.Position_Y + " " + rover.Direction);

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            Console.ReadLine();
        }
    }
}
