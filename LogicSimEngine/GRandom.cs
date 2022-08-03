﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LogicSimEngine
{
    public class GRandom
    {
        private Random _random;

        public GRandom(string seed)
        {
            var algo = SHA1.Create();
            var hash = BitConverter.ToInt32(algo.ComputeHash(Encoding.UTF8.GetBytes(seed)), 0);

            _random = new Random(hash);
        }

        public bool isTrue(int randomValue)
        {
            var num = getNum(0, 100);

            return num < randomValue;
        }

        public T RandomInGroup<T>(IEnumerable<(int value, T obj)> group)
        {
            var total = group.Sum(x => x.value);

            var num = getNum(0, total);

            var offset = 0;
            foreach (var elem in group)
            {
                if (num < elem.value + offset)
                {
                    return elem.obj;
                }

                offset += elem.value;
            }

            throw new Exception();
        }

        public int getNum(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}