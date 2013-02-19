using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FacadeAfter;

namespace FacadeBefore
{
    public class OrderViewModel
    {
        private readonly OrderService _service;

        public ObservableCollection<Recommendation> Recommendations { get; set; }

        public OrderViewModel(OrderService service)
        {
            _service = service;
            Recommendations = new ObservableCollection<Recommendation>();
        }

        public void HandleOrderExecuted(Order order)
        {
            _service.ExecuteOrder(order);
            PouplateRecommendations();
        }

        private void PouplateRecommendations()
        {
            Recommendations.Clear();
            foreach (var myRecommendation in _service.GetRecommendations())
                Recommendations.Add(myRecommendation);
        }
    }
}
