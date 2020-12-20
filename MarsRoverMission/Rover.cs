using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverMission
{
    /// <summary>
    /// Rover Class
    /// </summary>
    public class Rover
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Rover()
        {
            InitalizeParameter();
        }

        /// <summary>
        /// Position For X 
        /// </summary>
        private int position_x;
        public int Position_X
        {
            get { return position_x; }
            set
            {
                if (value > this.Max_X || value < 0)
                {
                    throw new Exception("X must be in boundaries !");
                }
                position_x = value;
            }
        }

        /// <summary>
        /// Position For Y
        /// </summary>
        private int position_y;
        public int Position_Y
        {
            get { return position_y; }
            set
            {
                if (value > this.Max_Y || value<0)
                {
                    throw new Exception("Y must be in boundaries !");
                }
                position_y = value;
            }
        }

        /// <summary>
        /// Directions
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Max value of X 
        /// </summary>
        private int Max_X { get; set; }

        /// <summary>
        /// Max Value of Y
        /// </summary>
        private int Max_Y { get; set; }



        /// <summary>
        /// Ä°nitialize class parameters
        /// assume that start position is  (0,0,N)
        /// </summary>
        private void InitalizeParameter()
        {
            this.Position_X = 0;
            this.Position_Y = 0;
            this.Direction = Direction.N;
        }


        /// <summary>
        ///       N
        ///       *
        ///       *
        /// W  ********* E
        ///       *
        ///       *
        ///       S
        /// Function for M Move, 
        /// For example  if current direction is N ,for M move  => position_y = y+1  
        /// For Example  if current direction is W ,for M move  => position_x = x-1
        /// </summary>
        private void Move_M()
        {
            switch (this.Direction)
            {
                case Direction.E:
                    this.Position_X += 1;
                    break;
                case Direction.W:
                    this.Position_X -= 1;
                    break;
                case Direction.N:
                    this.Position_Y += 1;
                    break;
                case Direction.S:
                    this.Position_Y -= 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Function for R Move
        /// </summary>
        private void Move_R()
        {
            switch (this.Direction)
            {
                case Direction.E:
                    this.Direction = Direction.S;
                    break;
                case Direction.W:
                    this.Direction = Direction.N;
                    break;
                case Direction.N:
                    this.Direction = Direction.E;
                    break;
                case Direction.S:
                    this.Direction = Direction.W;
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Function for L Move
        /// </summary>
        private void Move_L()
        {
            switch (this.Direction)
            {
                case Direction.E:
                    this.Direction = Direction.N;
                    break;
                case Direction.W:
                    this.Direction = Direction.S;
                    break;
                case Direction.N:
                    this.Direction = Direction.W;
                    break;
                case Direction.S:
                    this.Direction = Direction.E;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Validate method for start position input
        /// </summary>
        /// <param name="startPositionInput"></param>
        public void ValidateAndSetStartPosition(string startPositionInput)
        {
            if (string.IsNullOrEmpty(startPositionInput.Trim()))
            {
                throw new Exception("start position can not be nulll or empty!");
            }

            var positions = startPositionInput.Trim().Split(' ');
            if (positions == null || positions.Count() < 3)
            {
                throw new Exception("Invalid  position ! Please key correct position like 0 0 N ");

            }

            if (int.Parse(positions[0]) < 0 || int.Parse(positions[1]) < 0)
            {
                throw new Exception("Invalid  Position ! Please key positive number for position !");

            }

            if (int.Parse(positions[0]) > this.Max_X || int.Parse(positions[1]) > this.Max_Y)
            {
                throw new Exception("Invalid  Position ! Positions values must be between boundaries!");

            }

            int n;
            bool isNumeric = int.TryParse(positions[2], out n);
            if (isNumeric)
            {
                throw new Exception("Invalid  Direction ! Please key correct direction like  ( N-W-E-S ) !");

            }

            Direction direction;
            try
            {
                direction = (Direction)Enum.Parse(typeof(Direction), positions[2]);

            }
            catch (Exception ex)
            {
                throw new Exception("Invalid  Direction ! Please key correct direction  ( N-W-E-S ) !");
            }

            SetPosition(Convert.ToInt32(positions[0]), Convert.ToInt32(positions[1]), (Direction)Enum.Parse(typeof(Direction), positions[2]));
        }

        /// <summary>
        /// Set Position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        private void SetPosition(int x, int y, Direction direction)
        {
            this.Position_X = x;
            this.Position_Y = y;
            this.Direction = direction;
        }

        /// <summary>
        /// Set Boundaries
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void setBoundaries(string boundaires)
        {
            if (string.IsNullOrEmpty(boundaires.Trim()))
            {
                throw new Exception("Boundaries can not be nulll or empty!");
            }

            var boundary = boundaires.Trim().Split(' ').ToList();
            if (boundary == null || boundary.Count() != 2)
            {
                throw new Exception("Invalid Boundaries ! Please enter correct values !");
            }

            if (int.Parse(boundary[0]) < 0 || int.Parse(boundary[1]) < 0)
            {
                throw new Exception("Invalid Boundaries ! Please enter positive values !");
            }

            this.Max_X = int.Parse(boundary[0]);
            this.Max_Y = int.Parse(boundary[1]);
        }

        /// <summary>
        /// function for Move
        /// </summary>
        /// <param name="instructions"></param>
        public void Move(string instructions)
        {
            var validMoveList = new List<char> { 'L', 'M', 'R' };
            var invalidMove = instructions.ToCharArray().Where(e => !validMoveList.Contains(e));

            if (invalidMove != null && invalidMove.Count() > 0)
            {
                throw new Exception("Invalid  move character ! Please key correct move character  ( L,M,R) !");
            }

            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case 'M':
                        this.Move_M();
                        break;
                    case 'R':
                        this.Move_R();
                        break;
                    case 'L':
                        this.Move_L();
                        break;
                    default:
                        break;
                }

            }
        }

    }
}
