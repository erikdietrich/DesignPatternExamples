using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacadeBefore;

namespace FacadeAfter
{
    public class OrderService
    {
        private readonly EmailSender _emailSender;
        private readonly ReceiptPrinter _receiptPrinter;
        private readonly OrderDao _orderDao;
        private readonly ReceiptDao _receiptDao;
        private readonly RecommendationEngine _recommendationEngine;

        public OrderService(EmailSender emailSender, ReceiptPrinter receiptPrinter, OrderDao orderDao, ReceiptDao receiptDao, RecommendationEngine recommendationEngine)
        {
            _emailSender = emailSender;
            _receiptPrinter = receiptPrinter;
            _orderDao = orderDao;
            _receiptDao = receiptDao;
            _recommendationEngine = recommendationEngine;
        }

        public void ExecuteOrder(Order order)
        {
            _orderDao.StoreOrder(order);
            _emailSender.SendEmail(new OrderEmail(order));
            _receiptPrinter.PrintReceiptForOrder(order);
            _receiptDao.Save(order);
        }

        public IEnumerable<Recommendation> GetRecommendations()
        {
            return _recommendationEngine.GetRecommendations();
        }
    }
}
