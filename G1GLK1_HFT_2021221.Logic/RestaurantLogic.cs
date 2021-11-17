﻿using G1GLK1_HFT_2021221.Models;
using G1GLK1_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Logic
{
    class RestaurantLogic : IRestaurantLogic
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IConsumerRepository _consumerRepository;

        public RestaurantLogic(IRestaurantRepository restaurantRepository, IConsumerRepository consumerRepository)
        {
            _restaurantRepository = restaurantRepository;
            _consumerRepository = consumerRepository;
        }

        public Consumer ConsumerWithMostOrders(int restaurantID)
        {
            Restaurant restaurant = _restaurantRepository.GetOne(restaurantID);
            if (restaurant == null)
            {
                throw new Exception("restaurant cannot be found");
            }
            List<Order> orders = restaurant.Orders.ToList();
            
            int biggestCount = 0;
            int consumerWithMostOrders = 0;
            foreach (var currentOrder in orders)
            {
                int count = 0;
                foreach (var order in orders)
                {
                    if (order.ConsumerId == currentOrder.ConsumerId)
                    {
                        count++;
                    }
                }
                if (count > biggestCount)
                {
                    biggestCount = count;
                    consumerWithMostOrders = currentOrder.ConsumerId;
                }
            }
            return _consumerRepository.GetOne(consumerWithMostOrders);
        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            _restaurantRepository.Add(restaurant);
        }

        public void DeletRestaurant(int restaurantID)
        {
            Restaurant restaurant = _restaurantRepository.GetOne(restaurantID);
            if (restaurant == null)
            {
                throw new Exception("restaurant cannot be found!");
            }
            _restaurantRepository.Delete(restaurant);
        }

        public Restaurant GetRestaurant(int restaurantID)
        {
            Restaurant restaurant = _restaurantRepository.GetOne(restaurantID);
            if (restaurant == null)
            {
                throw new Exception("restaurant cannot be found!");
            }
            return restaurant;
        }

        public List<Restaurant> GetRestaurants()
        {
            return _restaurantRepository.GetAll().ToList();
        }

        public void UpdateCuisine(int restaurantID, string cuisine)
        {
            Restaurant restaurant = _restaurantRepository.GetOne(restaurantID);
            if (restaurant == null)
            {
                throw new Exception("restaurant cannot be found!");
            }
            restaurant.Cuisine = cuisine;
            _restaurantRepository.Update(restaurant);
        }

        public void UpdateLocation(int restaurantID, string location)
        {
            Restaurant restaurant = _restaurantRepository.GetOne(restaurantID);
            if (restaurant == null)
            {
                throw new Exception("restaurant cannot be found!");
            }
            restaurant.Location = location;
            _restaurantRepository.Update(restaurant);
        }

        public void UpdateName(int restaurantID, string name)
        {
            Restaurant restaurant = _restaurantRepository.GetOne(restaurantID);
            if (restaurant == null)
            {
                throw new Exception("restaurant cannot be found!");
            }
            restaurant.Name = name;
            _restaurantRepository.Update(restaurant);
        }
    }
}
