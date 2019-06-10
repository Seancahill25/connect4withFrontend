using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using connect4withFrontend;
using connect4withFrontend.Controllers;
using connect4withFrontend.Models;
using NUnit.Framework;
using static connect4withFrontend.Models.Board;

namespace connect4withFrontend.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        public State[,] board = new State[6, 7];
        State X = State.X;
        State O = State.O;
        State B = State.B;

        [Test]
        public void ReturnEmptyBoard()
        {
            State[,] input = new State[,]
            {
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B }
            };
            bool output = Board.CheckForWinner(input);
            bool expected = false;

            Assert.AreEqual(expected, output);
        }

        [Test]
        public void ReturnTrueIf4InARowHorizontal()
        {
            State[,] input = new State[,] 
            {
                { X, X, X, X, B, B, B },
                { B, B, B, B, B, B, B },
                { B, O, X, B, X, B, O },
                { B, B, B, B, B, B, B },
                { B, B, X, B, O, O, O },
                { B, X, X, B, X, B, B }
            };
            bool ouput = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, ouput);
        }

        [Test]
        public void ReturnTrueIfFourXInARowVertically()
        {
            State[,] input = new State[,] {
                { X, B, X, X, B, B, B },
                { X, B, B, B, B, B, B },
                { X, B, B, B, B, B, B },
                { X, B, B, B, O, O, O },
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B }
            };
            bool actual = Board.CheckForWinner(input);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourOInARowVertically()
        {
            State[,] input = new State[,] {
                { B, X, X, X, B, B, B },
                { B, B, B, B, B, B, B },
                { B, B, B, B, O, B, B },
                { B, X, B, B, O, O, O },
                { B, X, B, B, O, B, B },
                { B, X, B, B, O, B, B }
            };
            bool actual = Board.CheckForWinner(input);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourOInARowDiagonalLeft()
        {
            State[,] input = new State[,] {
                { X, B, B, B, B, B, B },
                { B, X, B, B, B, B, B },
                { B, B, X, B, B, B, B },
                { B, B, B, X, B, B, B },
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B }
            };
            bool actual = Board.CheckForWinner(input);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourOInARowDiagonalRight()
        {
            State[,] input = new State[,] {
                { X, B, B, B, B, B, O },
                { B, X, B, B, B, O, B },
                { B, B, X, B, O, B, B },
                { B, B, B, O, B, B, B },
                { B, B, B, B, B, B, B },
                { B, B, B, B, B, B, B }
            };
            bool actual = Board.CheckForWinner(input);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
