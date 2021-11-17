using G1GLK1_HFT_2021221.Models;
using G1GLK1_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Logic
{
    public class ConsumerLogic : IConsumerLogic
    {
        private readonly IConsumerRepository _consumerRepository;

        public ConsumerLogic(IConsumerRepository consumerRepository)
        {
            _consumerRepository = consumerRepository;
        }

        public void CreateConsumer(Consumer consumer)
        {
            _consumerRepository.Add(consumer);
        }

        public void DeleteConsumer(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            _consumerRepository.Delete(consumer);
        }

        public Consumer GetConsumer(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            return consumer;
        }

        public List<Consumer> GetConsumers()
        {
            return _consumerRepository.GetAll().ToList();
        }

        public void UpdateAdress(int consumerID, string address)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            consumer.Address = address;
        }

        public void UpdateName(int consumerID, string name)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            consumer.Name = name;
        }
    }
}
