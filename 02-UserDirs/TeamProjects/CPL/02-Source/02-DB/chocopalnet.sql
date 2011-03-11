-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Час створення: Бер 10 2011 р., 12:40
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
-- Stand-in structure for view `allproducts`
--
DROP VIEW IF EXISTS `allproducts`;
CREATE TABLE IF NOT EXISTS `allproducts` (
`id` int(11)
,`productname` varchar(300)
,`categoryname` varchar(250)
,`price` decimal(15,10)
,`description` varchar(250)
,`imagename` varchar(300)
,`imagepath` varchar(300)
);
-- --------------------------------------------------------

--
-- Stand-in structure for view `availabeproducts`
--
DROP VIEW IF EXISTS `availabeproducts`;
CREATE TABLE IF NOT EXISTS `availabeproducts` (
`id` int(11)
,`productname` varchar(300)
,`categoryname` varchar(250)
,`price` decimal(15,10)
,`description` varchar(250)
,`imagename` varchar(300)
,`imagepath` varchar(300)
);
-- --------------------------------------------------------

--
-- Структура таблиці `category`
--

DROP TABLE IF EXISTS `category`;
CREATE TABLE IF NOT EXISTS `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Дамп даних таблиці `category`
--

INSERT INTO `category` (`id`, `name`) VALUES
(1, 'Brick'),
(2, 'Candy'),
(3, 'Candyinbox'),
(4, 'Dragee');

-- --------------------------------------------------------

--
-- Структура таблиці `imagepath`
--

DROP TABLE IF EXISTS `imagepath`;
CREATE TABLE IF NOT EXISTS `imagepath` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=5 ;

--
-- Дамп даних таблиці `imagepath`
--

INSERT INTO `imagepath` (`id`, `name`) VALUES
(1, 'productimages/Brick/'),
(2, 'productimages/Candy/'),
(3, 'productimages/CandyInBox/'),
(4, 'productimages/Dragee/');

-- --------------------------------------------------------

--
-- Структура таблиці `product`
--

DROP TABLE IF EXISTS `product`;
CREATE TABLE IF NOT EXISTS `product` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categoryid` int(11) NOT NULL,
  `imagepathid` int(11) NOT NULL,
  `name` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  `price` decimal(15,10) NOT NULL,
  `shotdescription` varchar(250) COLLATE utf8_unicode_ci NOT NULL,
  `longdescription` varchar(1500) COLLATE utf8_unicode_ci NOT NULL,
  `fullimage` varchar(300) COLLATE utf8_unicode_ci NOT NULL,
  `sellstartdate` date NOT NULL,
  `sellenddate` date NOT NULL,
  `vendorid` int(11) NOT NULL,
  `ingredients` varchar(1500) COLLATE utf8_unicode_ci NOT NULL,
  `createdate` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=17 ;

--
-- Дамп даних таблиці `product`
--

INSERT INTO `product` (`id`, `categoryid`, `imagepathid`, `name`, `price`, `shotdescription`, `longdescription`, `fullimage`, `sellstartdate`, `sellenddate`, `vendorid`, `ingredients`, `createdate`) VALUES
(1, 1, 1, ' Dark chocolate', 7.9500000000, ' Dark chocolate  Dark chocolate  Dark chocolate  Dark chocolate Dark chocolate Dark chocolate Dark chocolate Dark chocolate', ' Dark chocolate  Dark chocolate Dark chocolate Dark chocolate Dark chocolate Dark chocolate Dark chocolate Dark chocolate', 'svDark.png', '2011-03-01', '2011-11-30', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(2, 1, 1, 'Milky chocolate', 7.5500000000, ' Milky chocolate  Milky chocolate  Milky chocolate', ' Milky chocolate  Milky chocolate  Milky chocolate  Milky chocolate  Milky chocolate', 'svMolochnuj.png', '2011-03-01', '2011-03-03', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(3, 1, 1, 'Special dark chocolate with nuts', 9.5500000000, 'Special dark chocolate with nuts', 'Special dark chocolate with nuts Special dark chocolate with nuts Special dark chocolate with nuts Special dark chocolate with nuts', 'svSpecDarkWithNuts.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(4, 1, 1, 'Special chocolate', 15.5500000000, 'Special chocolate Special chocolate', 'Special chocolate Special chocolate Special chocolate Special chocolate', 'svSpecial.png', '2011-03-01', '2011-12-05', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(5, 1, 1, 'Chocolate with tiramitsu', 8.5500000000, 'Chocolate with tiramitsu Chocolate with tiramitsu', 'Chocolate with tiramitsu Chocolate with tiramitsu Chocolate with tiramitsu Chocolate with tiramitsu Chocolate with tiramitsu', 'svTiramisu.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(6, 2, 2, 'Karpatu Svitoch', 25.5500000000, ' Karpatu Svitoch Karpatu Svitoch Karpatu Svitoch ', 'Karpatu Svitoch Karpatu Svitoch Karpatu Svitoch Karpatu Svitoch Karpatu Svitoch', 'svKarpatuSvitoch.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(7, 2, 2, 'Mak', 35.5500000000, 'Mak Candy Mak Candy Mak Candy ', 'Mak Candy Mak Candy Mak Candy Mak Candy Mak Candy', 'svMak.png', '2011-03-01', '2011-11-30', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(8, 2, 2, 'Romashka', 32.5500000000, 'Romashka Romashka Romashka', 'Romashka Romashka Romashka Romashk Romashka', 'svRomashka.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(9, 2, 2, 'Romashka Molochna', 27.5500000000, 'Romashka Molochna Romashka Molochna Romashka Molochna', ' Romashka Molochna Romashka Molochna Romashka Molochna Romashka Molochna', 'svRomashkaMolochna.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(10, 2, 2, 'Zorane Saivo', 45.5500000000, 'Zorane Saivo Zorane Saivo', 'Zorane Saivo Zorane Saivo Zorane Saivo Zorane Saivo', 'svZoraneSaivo.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(11, 3, 3, 'Palitra Molochnui Shokolad', 27.5500000000, 'Palitra Molochnui Shokolad Palitra Molochnui Shokolad', 'Palitra Molochnui Shokolad Palitra Molochnui Shokolad Palitra Molochnui Shokolad Palitra Molochnui Shokolad', 'svPalitraMolochnuiShokolad.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(12, 3, 3, 'Palitra Temnui Shokolad ', 32.5500000000, 'Palitra Temnui Shokolad  Palitra Temnui Shokolad ', 'Palitra Temnui Shokolad  Palitra Temnui Shokolad Palitra Temnui Shokolad  Palitra Temnui Shokolad ', 'svPalitraTemnuiShokolad.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(13, 3, 3, 'Palitra Vushukanuy Desert', 15.5500000000, 'Palitra Vushukanuy Desert Palitra Vushukanuy Desert Palitra Vushukanuy Desert', 'Palitra Vushukanuy Desert Palitra Vushukanuy Desert Palitra Vushukanuy Desert Palitra Vushukanuy Desert Palitra Vushukanuy Desert', 'svPalitraVushukanuDesertu.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(14, 4, 4, 'Arahis V Kakao', 15.5500000000, 'Arahis V Kakao Arahis V Kakao', 'Arahis V Kakao Arahis V KakaoArahis V Kakao', 'svArahisVKakao.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(15, 4, 4, 'Arahis V Kakao 90', 25.5500000000, 'Arahis V Kakao 90 Arahis V Kakao 90', 'Arahis V Kakao 90 Arahis V Kakao 90 Arahis V Kakao 90 v Arahis V Kakao 90 ', 'svArahisVKakao90.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07'),
(16, 4, 4, 'Arahis V Molochnom Shokoladi', 15.5500000000, 'Arahis V Molochnom Shokoladi Arahis V Molochnom Shokoladi', 'Arahis V Molochnom Shokoladi Arahis V Molochnom Shokoladi  Arahis V Molochnom Shokoladi Arahis V Molochnom ShokoladiArahis V Molochnom Shokoladi', 'svArahisVMolochShokoladi.png', '2011-03-01', '2011-11-21', 1, 'some cool ingredients without GMO, concervants and other', '2011-03-07');

-- --------------------------------------------------------

--
-- Структура таблиці `productcomments`
--

DROP TABLE IF EXISTS `productcomments`;
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

DROP TABLE IF EXISTS `vendor`;
CREATE TABLE IF NOT EXISTS `vendor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(1000) COLLATE utf8_unicode_ci NOT NULL,
  `address` varchar(1000) COLLATE utf8_unicode_ci NOT NULL,
  `phones` varchar(500) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=2 ;

--
-- Дамп даних таблиці `vendor`
--

INSERT INTO `vendor` (`id`, `fullname`, `address`, `phones`) VALUES
(1, 'Svitoch LLC', 'Lvov, Gasheka,45/3', '(065)234-234, (234)-234-231');

-- --------------------------------------------------------

--
-- Structure for view `allproducts`
--
DROP TABLE IF EXISTS `allproducts`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `allproducts` AS select `p`.`id` AS `id`,`p`.`name` AS `productname`,`c`.`name` AS `categoryname`,`p`.`price` AS `price`,`p`.`shotdescription` AS `description`,`p`.`fullimage` AS `imagename`,`i`.`name` AS `imagepath` from ((`product` `p` join `category` `c`) join `imagepath` `i`) where ((`p`.`categoryid` = `c`.`id`) and (`p`.`imagepathid` = `i`.`id`));

-- --------------------------------------------------------

--
-- Structure for view `availabeproducts`
--
DROP TABLE IF EXISTS `availabeproducts`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `availabeproducts` AS select `p`.`id` AS `id`,`p`.`name` AS `productname`,`c`.`name` AS `categoryname`,`p`.`price` AS `price`,`p`.`shotdescription` AS `description`,`p`.`fullimage` AS `imagename`,`i`.`name` AS `imagepath` from ((`product` `p` join `category` `c`) join `imagepath` `i`) where ((`p`.`categoryid` = `c`.`id`) and (`p`.`imagepathid` = `i`.`id`) and (`p`.`sellenddate` >= now()));
