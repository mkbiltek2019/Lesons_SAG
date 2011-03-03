-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Час створення: Бер 03 2011 р., 19:13
-- Версія сервера: 5.5.8
-- Версія PHP: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- БД: `chocoplanet`
--
CREATE DATABASE `chocoplanet` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `chocoplanet`;

-- --------------------------------------------------------

--
-- Структура таблиці `category`
--

CREATE TABLE IF NOT EXISTS `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

--
-- Дамп даних таблиці `category`
--


-- --------------------------------------------------------

--
-- Структура таблиці `imagepath`
--

CREATE TABLE IF NOT EXISTS `imagepath` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

--
-- Дамп даних таблиці `imagepath`
--


-- --------------------------------------------------------

--
-- Структура таблиці `product`
--

CREATE TABLE IF NOT EXISTS `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoryid` int(11) NOT NULL,
  `imagepathid` int(11) NOT NULL,
  `name` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  `price` decimal(10,0) NOT NULL,
  `shotdescription` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `longdescription` varchar(1500) COLLATE utf8_unicode_ci NOT NULL,
  `thumbnail` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  `fullimage` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  `sellstartdate` date NOT NULL,
  `sellenddate` date NOT NULL,
  `vendorid` int(11) NOT NULL,
  `ingredients` varchar(1500) COLLATE utf8_unicode_ci NOT NULL,
  `listprice` decimal(10,0) NOT NULL,
  `createdate` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

--
-- Дамп даних таблиці `product`
--


-- --------------------------------------------------------

--
-- Структура таблиці `productcomments`
--

CREATE TABLE IF NOT EXISTS `productcomments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `productid` int(11) NOT NULL,
  `comment` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

--
-- Дамп даних таблиці `productcomments`
--


-- --------------------------------------------------------

--
-- Структура таблиці `vendor`
--

CREATE TABLE IF NOT EXISTS `vendor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(1000) COLLATE utf8_unicode_ci NOT NULL,
  `address` varchar(1000) COLLATE utf8_unicode_ci NOT NULL,
  `phones` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

--
-- Дамп даних таблиці `vendor`
--

