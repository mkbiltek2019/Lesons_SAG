-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 26, 2011 at 12:07 
-- Server version: 5.5.8
-- PHP Version: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `cpl`
--
DROP DATABASE `cpl`;
CREATE DATABASE `cpl` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `cpl`;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `Id` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `Description` text COLLATE utf8_unicode_ci NOT NULL,
  `DatePlaced` date DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=4 ;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`Id`, `Name`, `Description`, `DatePlaced`) VALUES
(1, 'Chocolate', 'Black Chocolate, very tasty.', NULL),
(2, 'White Chocolate', 'The most delicious chocolate ever discovered.', NULL),
(3, 'Milk Chocolate', 'Simply delicious and time proved chocolate.', NULL);
