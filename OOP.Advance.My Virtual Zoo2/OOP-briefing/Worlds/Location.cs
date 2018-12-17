namespace OOPBriefing.Worlds
{
    class Location
    {

        private int _xCoord;
        private int _yCoord;
        private int _zCoord;

        public int XCoord
        {
            get
            {
                return _xCoord;
            }
            set
            {
                if (value > World.SizeX)
                {
                    _xCoord = World.SizeX;
                }
                else if (value <= 0)
                {
                    _xCoord = 0;
                }
                else
                {
                    _xCoord = value;
                }
            }
        }

        public int YCoord
        {
            get
            {
                return _yCoord;
            }
            set
            {
                if (value > World.SizeY)
                {
                    _yCoord = World.SizeY;
                }
                else if (value <= 0)
                {
                    _yCoord = 0;
                }
                else
                {
                    _yCoord = value;
                }
            }
        }

        public int ZCoord
        {
            get
            {
                return _zCoord;
            }
            set
            {
                if (value > World.SizeZ)
                {
                    _zCoord = World.SizeZ;
                }
                else if (value <= 0)
                {
                    _zCoord = 0;
                }
                else
                {
                    _zCoord = value;
                }
            }
        }


        public Location(int x = 0,int y = 0,int z = 0)
        {
            _xCoord = x;
            _yCoord = y;
            _zCoord = z;
        }


        public override string ToString()
        {
            return "XCoord - "+XCoord+", YCoord - "+YCoord+", ZCoord - "+ZCoord;
        }

    }

    public enum Direction
    {
        XDirection=0,
        YDirection=1,
        ZDirection=2
    }

    public enum BackOrForward
    {
        GoBack = -1,
        GoForward =1
    }
}
