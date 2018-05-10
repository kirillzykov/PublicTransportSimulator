using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportSimulator
{
    internal class BusStop
    {
        private int ID { get; set; }
        private double weight { get; set; }
        private string name { get; set; }
        private List<int> adjacentIdList { get; set; }
        private List<List<double>> adjacentRoadsList { get; set; }
        private List<int> routeList { get; set; }

        public BusStop()
        {
        }
    }
}