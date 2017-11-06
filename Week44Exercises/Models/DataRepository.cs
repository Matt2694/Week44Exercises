using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week44Exercises.Models
{
    public class DataRepository
    {
        private List<DataModel> _reservationRepository = new List<DataModel>();
        private static DataRepository _instance = new DataRepository();
        public static DataRepository Instance { get { return _instance; } }

        public void Add(DataModel newData)
        {
            _reservationRepository.Add(newData);
        }

        public List<DataModel> Get()
        {
            return _reservationRepository;
        }
    }
}
