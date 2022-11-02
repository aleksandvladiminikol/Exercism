using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercism
{
    internal static class QuestLogic
    {
        public static bool CanFastAttack(bool knightIsAwake)
        {
            return knightIsAwake is false;
        }
        public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
        {
            return (knightIsAwake || archerIsAwake || prisonerIsAwake);
        }
        public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
        {
            return (archerIsAwake is false && prisonerIsAwake is true);
        }
        public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
        {
            bool DogWay = petDogIsPresent && archerIsAwake is false;
            bool SneakyWay = knightIsAwake is false && archerIsAwake is false && prisonerIsAwake is true;
            return (DogWay || SneakyWay);
        }
    }
}
