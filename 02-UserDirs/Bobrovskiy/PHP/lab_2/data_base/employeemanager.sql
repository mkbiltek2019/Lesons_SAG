-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Час створення: Лют 26 2011 р., 05:56
-- Версія сервера: 5.5.8
-- Версія PHP: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- БД: `employeemanager`
--

-- --------------------------------------------------------

--
-- Структура таблиці `department`
--

CREATE TABLE IF NOT EXISTS `department` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=6 ;

--
-- Дамп даних таблиці `department`
--

INSERT INTO `department` (`id`, `name`) VALUES
(1, 'IT'),
(2, 'QA'),
(3, 'Management'),
(4, 'Deployment'),
(5, 'Help Desk');

-- --------------------------------------------------------

--
-- Структура таблиці `employee`
--

CREATE TABLE IF NOT EXISTS `employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `departmentid` int(11) NOT NULL,
  `peopleid` int(11) NOT NULL,
  `positionid` int(150) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Дамп даних таблиці `employee`
--

INSERT INTO `employee` (`id`, `departmentid`, `peopleid`, `positionid`) VALUES
(1, 3, 1, 6),
(2, 2, 2, 5),
(3, 1, 2, 5),
(4, 2, 1, 5);

-- --------------------------------------------------------

--
-- Структура таблиці `employeeposition`
--

CREATE TABLE IF NOT EXISTS `employeeposition` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET latin1 NOT NULL,
  KEY `id` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=cp1251 COLLATE=cp1251_ukrainian_ci AUTO_INCREMENT=9 ;

--
-- Дамп даних таблиці `employeeposition`
--

INSERT INTO `employeeposition` (`id`, `name`) VALUES
(5, 'worker'),
(6, 'manager'),
(7, 'security');

-- --------------------------------------------------------

--
-- Структура таблиці `people`
--

CREATE TABLE IF NOT EXISTS `people` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(150) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=36 ;

--
-- Дамп даних таблиці `people`
--

INSERT INTO `people` (`id`, `name`) VALUES
(1, 'Ivan'),
(2, 'Vasyl'),
(3, 'Petro'),
(4, 'qwerty'),
(5, 'qwery2'),
(6, 'qwreertyttut4'),
(7, 'qwreertyttut4'),
(34, 'asdfdfg'),
(35, 'erty');
