﻿using G1GLK1_HFT_2021221.Models;
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
        //private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public ConsumerLogic(IConsumerRepository consumerRepository,  IRestaurantRepository restaurantRepository)
        {
            _consumerRepository = consumerRepository;
            //_orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
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

        public string MostOftenOrderedFood(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            List<Order> orders = consumer.Orders.ToList();
            int biggestCount = 0;
            string food = "";
            foreach (var currentOrder in orders)
            {
                int count = 0;
                foreach(var order in orders)
                {
                    if (order.Food == currentOrder.Food)
                    {
                        count++;
                    }
                }
                if (count > biggestCount)
                {
                    biggestCount = count;
                    food = currentOrder.Food;
                }
            }
            return food;
        }

        public Restaurant MostOrdersFromRestaurant(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            List<Order> orders = consumer.Orders.ToList();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var order in orders)
            {
                restaurants.Add(_restaurantRepository.GetOne(order.RestaurantId));
            }

            int biggestCount = 0;
            Restaurant mostUsedRestaurant = new Restaurant();
            foreach (var currentRestaurant in restaurants)
            {
                int count = 0;
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.Name == currentRestaurant.Name)
                    {
                        count++;
                    }
                }
                if (count > biggestCount)
                {
                    biggestCount = count;
                    mostUsedRestaurant = currentRestaurant;
                }
            }
            return mostUsedRestaurant;
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
