-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Час створення: Бер 02 2011 р., 10:55
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
CREATE DATABASE `employeemanager` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `employeemanager`;

-- --------------------------------------------------------

--
-- Структура таблиці `department`
--

DROP TABLE IF EXISTS `department`;
CREATE TABLE IF NOT EXISTS `department` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) CHARACTER SET latin1 NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=10 ;

--
-- Дамп даних таблиці `department`
--

INSERT INTO `department` (`id`, `name`) VALUES
(2, 'QA'),
(3, 'Management'),
(4, 'Deployment'),
(5, 'Help Desk'),
(9, 'IT');

-- --------------------------------------------------------

--
-- Структура таблиці `employee`
--

DROP TABLE IF EXISTS `employee`;
CREATE TABLE IF NOT EXISTS `employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `departmentid` int(11) NOT NULL,
  `positionid` int(150) NOT NULL,
  `name` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `id` (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=14 ;

--
-- Дамп даних таблиці `employee`
--

INSERT INTO `employee` (`id`, `departmentid`, `positionid`, `name`) VALUES
(1, 3, 6, 'Ivan'),
(2, 2, 5, 'Vasul'),
(3, 0, 0, 'Petro'),
(4, 9, 7, 'Taras'),
(13, 3, 5, 'retw');

-- --------------------------------------------------------

--
-- Структура таблиці `employeeposition`
--

DROP TABLE IF EXISTS `employeeposition`;
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
