using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace FacadeBefore
{
    public class OrderViewModel
    {
        private readonly EmailSender _emailSender;
        private readonly ReceiptPrinter _receiptPrinter;
        private readonly OrderDao _orderDao;
        private readonly ReceiptDao _receiptDao;
        private readonly RecommendationEngine _recommendationEngine;

        public ObservableCollection<Recommendation> Recommendations { get; set; }

        public OrderViewModel(EmailSender emailSender, ReceiptPrinter receiptPrinter, OrderDao orderDao, RecommendationEngine engine, ReceiptDao receiptDao)
        {
            _emailSender = emailSender;
            _receiptPrinter = receiptPrinter;
            _orderDao = orderDao;
            _recommendationEngine = engine;
            _receiptDao = receiptDao;
            Recommendations = new ObservableCollection<Recommendation>();
        }

        public void HandleOrderExecuted(Order order)
        {
            ExecuteOrder(order);
        }

        private void ExecuteOrder(Order order)
        {
            _orderDao.StoreOrder(order);
            _emailSender.SendEmail(new OrderEmail(order));
            _receiptPrinter.PrintReceiptForOrder(order);
            _receiptDao.Save(order);

            PouplateRecommendations();
        }

        private void PouplateRecommendations()
        {
            Recommendations.Clear();
            foreach (var myRecommendation in _recommendationEngine.GetRecommendations())
                Recommendations.Add(myRecommendation);
        }
    }
}
