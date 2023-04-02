-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 16, 2021 at 01:08 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sdm`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `Username` varchar(25) COLLATE utf8mb4_unicode_ci NOT NULL,
  `EmpID` int(11) DEFAULT NULL,
  `Password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Role` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Email` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `AccountStatus` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SecretQuestion` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `Answer` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`Username`, `EmpID`, `Password`, `Role`, `Email`, `AccountStatus`, `SecretQuestion`, `Answer`) VALUES
('Edison1', 400003, 'Edison1!', 'Owner', 'owner1@gmail.com', 'Active', 'What elementary school did you attend?', 'Sekolah Kebangsaan Klang'),
('Fulltime1', 400007, 'Fulltime1!', 'Full-Time Staff', 'fulltime1@gmail.com', 'Active', 'What is the name of the town where you were born?', 'Kiana'),
('Fulltime2', 400004, 'Fulltime2!', 'Full-Time Staff', 'fulltime2@gmail.com', 'Active', 'What is the name of the town where you were born?', 'Reefes'),
('Fulltime3', 400009, 'Fulltime3!', 'Full-Time Staff', 'fulltime3@gmail.com', 'Active', 'What was your first car?', 'Honda Civic'),
('Milla1', 400008, 'Milla1!', 'Assistant Manager', 'assmanager1@gmail.com', 'Active', 'What is the name of your first pet?', 'Geld'),
('Opsmanager1', 400002, 'Opsmanager1!', 'Operational Manager', 'opsmanager1@gmail.com', 'Active', 'What is the name of your first pet?', 'Lucky'),
('Parttime1', 400005, 'Parttime1!', 'Part-Time Staff', 'parttime1@gmail.com', 'Active', 'What elementary school did you attend?', 'Sekolah Kebangsaan Meru'),
('Parttime2', 400006, 'Parttime2!', 'Part-Time Staff', 'parttime2@gmail.com', 'Active', 'What elementary school did you attend?', 'Sekolah Kebangsaan KL'),
('Parttime3', 400010, 'Parttime3!', 'Part-Time Staff', 'parttime3@gmail.com', 'Active', 'What was your first car?\r\n', 'Perodua Kembara'),
('Sysadmin1', 400001, 'Sysadmin1!', 'System Administrator', 'sysadmin1@gmail.com', 'Active', 'What is your mothers maiden name?', 'Alice Liam');

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `ClientID` int(10) NOT NULL,
  `ClientName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ClientEmail` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ContactPerson` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `PhoneNo` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `AltContactPerson` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `AltPhoneNo` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `Property` varchar(100) NOT NULL,
  `Address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `PoolSize` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ChargeRate` decimal(10,2) NOT NULL,
  `NumOfPoolBar` int(2) NOT NULL DEFAULT 0,
  `NumOfOutdoorPool` int(2) NOT NULL DEFAULT 0,
  `NumOfWaterfall` int(2) NOT NULL DEFAULT 0,
  `NumOfSlide` int(2) NOT NULL DEFAULT 0,
  `AddCharge` decimal(10,2) NOT NULL DEFAULT 0.00,
  `PoolRemarks` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '\'\'',
  `ScheduleType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `ScheduleRemarks` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '\'\''
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`ClientID`, `ClientName`, `ClientEmail`, `ContactPerson`, `PhoneNo`, `AltContactPerson`, `AltPhoneNo`, `Property`, `Address`, `PoolSize`, `ChargeRate`, `NumOfPoolBar`, `NumOfOutdoorPool`, `NumOfWaterfall`, `NumOfSlide`, `AddCharge`, `PoolRemarks`, `ScheduleType`, `ScheduleRemarks`) VALUES
(300001, 'Stargaze Hotel', 'stargaze hotel@service.com', 'John Connor', '0112293765', 'Emily Chan', '0171103504', 'Hotel', 'Jalan 1/91, Taman Shamelin Perkasa', 'Large', '400.00', 1, 1, 0, 2, '1100.00', '', 'Bi-Weekly', 'During summer, advise change schedule to weekly'),
(300002, 'Keanu Bungalow', 'keanu1@yahoo.com', 'Keanu Reeves', '0111777782', '', '', 'House', 'G Yow Chuan Plaza Jln Tun Razak', 'Small', '200.00', 0, 0, 1, 0, '500.00', '', 'Bi-Monthly', ''),
(300003, 'Sky Eco Apartment', 'skyeco@service.com', 'Micheal Jackson', '012389573', 'Michella Obama', '0111111220', 'Apartment', 'Jalan Toman 3, Kemayan Square', 'Medium', '300.00', 0, 1, 0, 2, '400.00', '', 'Monthly', ''),
(300004, 'Comples Uos Hotel ', 'uosservice@gmail.com', 'Uoso Monelle', '0199827323', 'Sasa Monella', '0199827222', 'Hotel', 'Comples  3 Wisma Hla Jln Raja Chulan', 'Complex', '600.00', 1, 1, 1, 1, '1500.00', '', 'Weekly', ''),
(300005, 'Sungaze Hotel', 'sungazehotel@service.com', 'John Boomer', '0113293765', 'Emily Boom', '0172203450', 'Hotel', 'No 129 Jalan Sultan Iskandar Shah', 'Large', '400.00', 1, 1, 0, 0, '900.00', '', 'Bi-Weekly', 'During summer, advise change schedule to weekly'),
(300006, 'Johnson Mansion', 'johnson 1@gmail.com', 'Johnson Love', '0122505041', '', '', 'House', 'Jalan Usj 1/33, Taman Subang Permai', 'Small', '200.00', 0, 0, 1, 0, '500.00', '', 'Bi-Monthly', ''),
(300007, 'Mohammad Bungalow', 'mohammad1@yahoo.com', 'Mohammad Bin Huzalifi', '0111777782', '', '', 'House', 'No. 120 Lorong Hang Jebat', 'Small', '200.00', 0, 0, 1, 0, '500.00', '', 'Bi-Monthly', ''),
(300008, 'Mirth Green Apartment', 'mirthapartment@helpservice.com', 'Mirth Keys', '011662510', '', '', 'Apartment', 'Bangunan Ghee Hong Jln Ampang', 'Medium', '300.00', 0, 0, 0, 0, '0.00', '', 'Monthly', ''),
(300009, 'Brass Ridge Apartment', 'brassridge@helpservice.com', 'Ridge Talison', '011662510', 'Azza binti Razeen', '011660152', 'Apartment', '82 10 20 De Tropicana Condo Jalan Kuchai Lama', 'Medium', '300.00', 0, 0, 0, 0, '0.00', '', 'Monthly', '');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `EmpID` int(10) NOT NULL,
  `FName` varchar(70) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Address` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `PhoneNo` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL,
  `AltPhoneNo` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `DOB` date NOT NULL,
  `MaritalStatus` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Title` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Position` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Status` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `StartDate` date NOT NULL,
  `SalaryType` varchar(10) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Salary` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`EmpID`, `FName`, `Address`, `PhoneNo`, `AltPhoneNo`, `DOB`, `MaritalStatus`, `Title`, `Position`, `Status`, `StartDate`, `SalaryType`, `Salary`) VALUES
(400001, 'Daniel bin Bestari', 'Oakland Commerce Square 60-1 Jln Haruan Address', '0123456789', '0123456788', '1990-01-30', 'Married', 'Manager', 'System Administrator', 'Full-Time', '2018-05-01', 'Monthly', '4000.00'),
(400002, 'Alan Chris', 'Blok A Diamond Square Jln 3/52', '0115547110', '', '2000-02-19', 'Single', 'Manager', 'Operational Manager', 'Full-Time', '2015-01-01', 'Monthly', '3700.00'),
(400003, 'Edison Owens', '12 Jln 3/3A Sri Hartamas', '0158844551', '', '1989-01-14', 'Married', 'Manager', 'Owner', 'Full-Time', '2015-05-15', 'Monthly', '8000.00'),
(400004, 'Tan Chong Kek', 'Level 9 Menara Pelangi', '0122365847', '', '2000-01-20', 'Single', 'Staff', 'Pool Maintenance Staff', 'Full-Time', '2019-01-01', 'Monthly', '1800.00'),
(400005, 'John Connor', 'Sunway Mas Commecial Jln Pju 1/3B', '0174815213', '', '1999-05-15', 'Single', 'Staff', 'Pool Maintenance Staff', 'Part-Time', '2020-03-01', 'By Slot', '40.00'),
(400006, 'Naveen Tikaram', 'No. 563 Taman Clonlee', '0171236834', '', '2000-05-15', 'Single', 'Staff', 'Pool Maintenance Staff', 'Part-Time', '2020-01-01', 'By Slot', '40.00'),
(400007, 'Aadam bin Yoosuf', '67/1 Jalan Haji Abdul Aziz', '012236231', '', '1997-01-20', 'Single', 'Staff', 'Pool Maintenance Staff', 'Full-Time', '2019-05-01', 'Monthly', '1800.00'),
(400008, 'Milla Mamee', '58 Jln Tun Perak', '0196895002', '', '1990-01-14', 'Married', 'Manager', 'Assistant Manager', 'Full-Time', '2016-05-15', 'Monthly', '5500.00'),
(400009, 'Jayadev Mitali', 'Jln 51A/222 Seksyen 51A Petaling Jaya', '0168744510', '', '1996-02-15', 'Single', 'Staff', 'Pool Maintenance Staff', 'Full-Time', '2019-03-01', 'Monthly', '1800.00'),
(400010, 'Katijah binti Agung', 'No.32 Jalan Kampung Baru', '0178903930', '', '1999-07-15', 'Single', 'Staff', 'Pool Maintenance Staff', 'Part-Time', '2020-01-01', 'By Slot', '40.00');

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `ItemCode` int(10) NOT NULL,
  `ItemCategory` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ItemName` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Description` varchar(500) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Quantity` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`ItemCode`, `ItemCategory`, `ItemName`, `Description`, `Quantity`) VALUES
(900001, 'Pool Filter', 'Side-Mount Filter', 'The material of sand filter is fiberglass reinforced plastics, it has good wear resistance, corrosion resistance and keep a stable shape. Uniquely designed distribution make a stable and even water flow to improve drainage system. And it is easy to install, maintain. Also the outlet turbidity of sand filter is < 2FTU.', 2),
(900002, 'Pool Filter', 'FX24 Underground Filter ', 'The FX24 Underground Pipeless Pool Sand Filter filtration system is easy to install, easy to operate, and has high filtration accuracy. It is suitable for various types of swimming pool water treatment.\r\n\r\n\r\nThe FX24 Underground Pipeless Pool Sand Filter filtration system is easy to install, easy to operate, and has high filtration accuracy. It is suitable for various types of swimming pool water treatment.\r\n\r\n', 2),
(900003, 'Pool Filter', 'DF10 Pipeless Filter', 'Integrative swimming pool filter FX25 is made of A grade polyvinyl chloride. It has unique one-time plastic molded, small shape, humanized design.', 3),
(900004, 'Pool Filter', 'FX36 Underground Pipeless Filter', 'Degaulle FX36 Underground Pipeless Pool Cartridge Filter is an all-in-one machine can be placed in a convenient location around the swimming pool (buried underground) without the need to build a machine room, thereby reducing construction costs. Simple installation, well-equipped, excellent performance, in line with swimming pool specifications and standards.\r\n\r\n', 2),
(900005, 'Pool Heat Pump', 'DGL-100C Degaulle Air Source Heat Pump', 'Heat pump collect heat from air by 20 ℃ below the refrigerant and compress heat into high temperature and high pressure refrigerant, and then passed through the heat transfer to the need to be heated water or other media', 1),
(900006, 'Pool Heat Pump', 'DGL-120C Degaulle Air Source Heat Pump', 'Heat pump collect heat from air by 20 ℃ below the refrigerant and compress heat into high temperature and high pressure refrigerant, and then passed through the heat transfer to the need to be heated water or other media', 2),
(900007, 'Pool Heat Pump', 'DGL-300C Degaulle Air Source Heat Pump', 'Heat pump collect heat from air by 20 ℃ below the refrigerant and compress heat into high temperature and high pressure refrigerant, and then passed through the heat transfer to the need to be heated water or other media', 3),
(900008, 'Pool Water Pump', 'SWP Series Water Pump', 'The inlet and outlet of Water Pump is reinforced with stainless stee, which is integrative and easy to install.', 1),
(900009, 'Pool Water Pump', 'HLG Series Pool Water Pump', 'Degaulle Pool HLW Series Pool Water Pump designed pump body has low noise and quiet operation. The pump body, flange, and slag basket are made of glass fiber filled GF/PP, and the impeller is made of glass fiber filled polyphenylene oxide.', 1),
(900010, 'Pool Water Pump', 'HZS Series Pool Water Pump', 'Degaulle Pool HZS Series Water Pump is suitable for small swimming pools, hydromassage baths and other occasions. It can also be used as water circulation in hotels, aquaculture, etc., as well as circulating filtration of fresh water and sea water. The pump body, pump cover and impeller are made of high-quality reinforced engineering plastics.', 1),
(900011, 'Pool Light', 'DN-6010 Stainless Steel Embedded Pool Light', 'This type of DN-6010 pool lights is made by Stainless steel#304 which with embedded installation method for your concrect swimming pool.', 5),
(900012, 'Pool Light', 'DN-8003 Stainless Steel Wall-Mounted Pool Light', 'This type of DN-6004 pool lights is made by ABS which with wall-mounted installation method for your concrect swimming pool.', 6),
(900013, 'Pool Light', 'DN-6017V Linear Pool Light', 'This type of DN-6017V pool lights is made by ABS which with embedded installation method for your liner swimming pool.', 5),
(900014, 'Pool Cleaner', 'Cordless Pool Vacuum', 'Small Cordless Pool Vacuum. Comprehensive cleaning, strong suction, easy to absorb all kinds of swimming pool dirt and make the pool water clear!', 4),
(900015, 'Pool Cleaner', 'HJ2042L Automatic Pool Cleaner', 'This HJ2042L swimming pool cleaner is automatic which can clean the bottom and wall of the pool automatic, and it can save more time, labor, cost of cleaning the pool.', 4),
(900017, 'Pool Accessories', 'Standard Pool Drain', 'These pool drains are manufactured from high quality ABS plastic, corrosion and UV resistant. Available both for private and commercial pools.', 10),
(900018, 'Pool Accessories', 'SF Series Pool Ladder', 'Pool ladder to allow swimmers to climb out of the swimming pool', 8),
(900019, 'Pool Accessories', 'Pool Gutter Grating', 'As a plastic cover of the drainage ditch around the swimming pool, Pool Grating is used for overflowing, preventing people from stepping into the ditch accidentally, and preventing people from slipping to the side.', 320);

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--

CREATE TABLE `jobs` (
  `JobID` int(10) NOT NULL,
  `ClientID` int(10) DEFAULT NULL,
  `JobType` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `JobStatus` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Picture` blob DEFAULT NULL,
  `PictureType` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `JobRemarks` text COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `EmpID` int(10) DEFAULT NULL,
  `SupEmpID` int(11) DEFAULT NULL,
  `SupEmpID2` int(11) DEFAULT NULL,
  `ItemCode` int(10) DEFAULT NULL,
  `MaintenanceCharge` decimal(10,2) NOT NULL DEFAULT 0.00,
  `date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `jobs`
--

INSERT INTO `jobs` (`JobID`, `ClientID`, `JobType`, `JobStatus`, `Picture`, `PictureType`, `JobRemarks`, `EmpID`, `SupEmpID`, `SupEmpID2`, `ItemCode`, `MaintenanceCharge`, `date`) VALUES
(500001, 300001, 'Cleaning', 'Completed', NULL, '', '', 400004, 400005, NULL, 900015, '0.00', '2021-06-16'),
(500002, 300001, 'Cleaning', 'Pending', NULL, '', '', 400004, 400006, NULL, 900015, '0.00', '2021-06-30'),
(500003, 300002, 'Maintenance', 'Completed', 0xffd8ffe000104a46494600010100000100010000ffdb0084000a0708151514181515151918181a1a1a191b1b1b181d1a1b1b1d1b1a1a1b1a1b1b1a21212d241b1d2a211a1a2537252a2f313434341a243a3f3a333e2d333431010b0b0b100f101f12121f332a232b3533333533333333353333353333333333333333333333353333353333333333333334333433333333333333333333333333ffc000110800b0011e03012200021101031101ffc4001c0000010501010100000000000000000000030102040506070008ffc40043100002000403040607040a010403000000010200031121041231054151610622718191f0133252a1b1c1d1428292e107141623536272a2d2f1c2333443b21793e2ffc400190100030101010000000000000000000000020304000105ffc4002c110002020201040104000603000000000000010211032131041213415105223261147191a1b1d1234281ffda000c03010002110311003f008389e9362733f5a82acab97d5b1142ad43985b71df0f97d2d9ad21918d1ac04c068d41ae8396bac63e4e2a6a2e501b21a12283b2a0eeecd0d227cb92e6aa75d780d3507b627791a5c99422fd1a5c36daf4ea92dea5e5d7afed2d85f983bf7d625b2d69de3e63dff18ceec7c338999fd1b8a59c804a80dc4e805403dd1a502deff0bc5b825dd1159234c455af7fcff310645f3dbf988544f9d3bee3df0744f3dbf9c3c00689e7de3e620a13cf9e5f082a279edfce0a89e7de3e623188e25f9f3e6f0f09e7cf9d60d93cf9e5f08764f3e7cde3862394f3e7ceb0813cf9f3ac49c9e7cf9d617d1c70e91b2c391388d6d7df5b52240484992032956150c082388362238cc5462704b2b2aa80055ca814b020122dd9e113367258f68874bd8925548972d118dc385eb56b517d48aee836ce4f581142080470235f3ce279c1ad8f8caf4485487fa38322419521619144a84f471384b814e4214d35a1a76d2d18c57cd60a69eb31d145cf7f01ccc3060d9af334dc834fbc7ed7c230737a518b9531a59281a88c4e45be74571adcfad4824be9a62b8a1fb83e4d0f82484c9b6740123cee85fd5a30f2fa658af653f01ff3890bd34c40d65cbfc0ff00e50609b0fd5e10e1a324bd389bbe521ee71f387feddbef929f8987ca3a728d49c3c34e1e3307a7877c85ff00ec3fe30a3a7a37c81dd33ffcc74e1a3387e5036c3c510e9e26fc3b77383ff185fdbb95be43fe2531dd9ad170d8681361e2b0f4ea47f0a60fc3f584fdb7c37f0e68fbabfe51b672d160d8780b61f979f3dc2221e9ae17d899f847f9434f4cb09c267e01fe5a728c774496c3f9f3f180b48f34af80e1ce02dd30c1ff003fe0d7b6fee81bf4b3075f5a601c92e4f3bc6b31412516580c70d2a49e3326366f57d9357d6da6847643713b7e5823283308ad2d912fdb563ee8cd38626b466af224d0c2feacfec37e13f4881e25276d14d9b0d91d269c25ba4bcaa1acea0900a9ad29ad295a54f1dd68b97da92a5901de8480c2c4d8e9a03181c08988e0846a687aba8de2fca2c36d0ce11eac154e4394dc29a95b1234a1e1ac330dc1b8d6bd0b9a4cd6aedfc381ff005377b0fb8f57ecc1474930ded36ffb0fda3ecf18c9c9e8d4c6008973c822a0e6962a0e87d731370fd0d9ac69e86677ce963e00c51debe41f1b345fb5186e2fbfff001bf6f0e30ffdadc37f3fe03f3e714ffb07300a9934feac40ff008cb87cbe8336f972876cd987e082377af9378d9667a5f87e133f00ff002ed86bf4cf0fecbf820ff9f080274139491dd35bfe620c9d075ded2bba539f8cd8de489bc6c1b74e247f0dff00b3fca187a7727f8533c53ebd91397a152b7baf74a5f9930f1d0b93edb7724a1ff0303e589bc6cab3d3c97ba53fe3586fedf4bfe0b7e31f48bb5e88c81bdcf74b1f0482af4530fc1cfdfa7c291bc88de36507ff0020a7f05bf18ff18b6d9fd23133132657a2c8674b47cc5ea3d1b06c84d00a1d7c6257ecae177a31fbeffe51e9db2e5cb32664b5a34b7972eb527f7798a05b9dc581aeb681734f412835b342ab0654862c154c2c61ef470379701da69308512a6fa1b9ab80a4e950006b6e307c3215450d30cc6a5dcd2adced6f08166f6707dad84796ee930e66498e84d49f5682c4de9c222e0b0d531b3e9f6ca227198ba3b3135b75ad61c6a057b8c66f00904a9836ae87e264e496cc2d4115b81f49941ceff88fd62e76dda41e669f2f9c57e0658cbbebee8248d27b0a1e60fb6dde6bf186ae22697a29cd450482a3524dac2bbbdf121844ed8785a976e741dd63ef5f7c1a72f905a442093cfd85f0a47bd0ccde89e7ef46a4e1a00f878ddd239da8c9e2a604f5914eb5a3694e3630169ca17334a2a3fa8189d8e959a604b6b434ed2cdf3115db4d733841a0d7b4fd3eb02f24bb945051c6bb5b67bf5a967730f3db09e9a5fb4c3c7eb0dfd410d32cf97f784d5f79974f7c78ec9984d11a5bff0044e964fe1ce1bdd07df25e81ec8bf63f3cbf6cff0077d21a4a7f100ed207c440a7ec89e82ad266538e4623c40a4564d119647f067045b6553a4c5fc4b08647f38fed8a4a42111bc9fa39e33bd26c7c2ff057f0cd7820d9387dd225f7e19ebfdc622746f6c4bc4cbbf5662d33ae79adf7805fb27dda45efa35e00f6ca73ff00b308f31ce5edb3d1ec8fa4424c0cb1a61d3ba4cb5ffd9a283a63b3d5b234b5a2b751d464a8a559480b6aebe11aa608b72aabcf24a5f8b1303c7d264b644356b32f594d1d4e643444e206f82c73a926d83385c5a467ba26584b32df596d94735203211c88368d22a6b7a58de2a360e520d16845073c86ac80ff004e665ed5317d2d22992a64eb68acc4e0a605621e8e012b536a8b8d79c59c87cc8aded007c4562362b63acc72e5dd6a0542d00b5ab707944dc36184b4540490a282a6a63add8318d0b485021d48f18e043691e221d1e8c61b963c161d091c308440e5a0350456f5fee247be0d034d4c63a1d4c3c180830ecf1acd42e224acc147198035a5f5d3776c7a7e21652027d5140282b4dc21ca62a3a4e1bd0d65d3383d526f4b1ad3b8472575a392bad198e946265cc43e925b33afa4c8149b10ec4e6a1d280f3f8c62f679de22e36ca36449ccb94996d4ca728a8639b28d73509bd0fad10d40ead251434addab55342a69414b78fc763744f14fbac07481aa88bc5bf3f94024da91edb4f5988bc013e7c6192cc50836b649aef31a2d852f2ca5e26e7be3344d6dc683c481f38d861000a070148247095488b8960013c01312ab157b6a752591c4d3e67e1055671bad99c0f77987ec8fee635fa78c57aa6ac753f13e4c1b10f60b706a5daa08d7d5d7f9690d6d00eff3e77c7210b6dfcff834e549222b4b80bcb894e60330c33b45d9154e5a9048e3434af234812cf7160ec0700c69e1a43e7379f8400c2a4864429c53ef20f6a29f88867eb1c510fdd23e0440cc2181a0acbcd9d8d794eb325b1561704137e20d350784752d8bb5a56265e6ca9987aea514e53daef707718e3d2dc03c8dc7d3bb48d1f43926be325248243b305275193572d6d02827b84473c77c16c27f276fd85800ea58d96b450a10034d4f54776b16b3b0b2d119dab4552c4e66d00a9df12e4ca08a1468052283a7b8df45819a77b812c7df343fdb9a1b1824b689e536de8c3ecac62fa546161396a07f555b8d6ce1c7df11ad962399ece72d272dc3c96131792b5330ec0c0784747c06204c96ae346507b2bbbb8da0e6b860c3da25811e223d584630018861b08c6184c630fac7ab0cac2d631858f47ab0918c7ab0d4d4f9e10eac310dcf9e118c161612b1e8c10f10dc4a2b232b6841aebf2bc23b85152691065ed2ab329c80653421b3549d0d74a404a697273769246226cc560254c01c4b50841045332231028456aa50f6c504af5d80ae504aad493400d00a9ec8d3e3b66cc189725481319181d45e4cb0c330b543023ba27e23a29288065b143c3d615d4f382538692673c6f9a39f6265179ad4fb2001efafca10c965d47847b1f9a4cf7598190e63a822a05054545c1a6b1224cc56be61e79c3530681e1987a45a9b039bc07d488d24ac70dc2b14225a963a9a5070bd2ba8ed10797e917d56a8e0c2b4ef86c62df0265251e4bd18b63a08a3db73cb1ca4f2eccd6f76b0e38a6a75d58002e47597dda784412eacf526835a6f35b0a0ecac3a38d7c8a965d550f121686e4f8b7c6203eb16a98814b29af3b0ee158898e9ccdad29c87cf53e30ef124b423f886e54c80c223cc8942695d3de011e061bb4718af97a8ab4ae6cb6cda6a00a0ee1c6064a90d8bb65539a986448210ef23babef80b2c4cd0f4c198430e30d30274948baaef171f31e1f08ed7fa1dd81925363260eb4deacbaee960f59bef30f051c6397f467613637152e42d454e6761f6116eeddb4b0e6c23e97c361d65a2cb450a8aa115468154500f01098ef63e5f6e8308e71fa5bc77fdbc81f68b39ee1957de4c7488e33d36c589bb49856ab2f2a7802cdef3042caad9e0ca9885d46472c8d4d0ab541efbf0dd58d9f4798a0794c00c8c72d2c295a1a0dd715fbe229151590ab014614e1af1e079ff00a317a473e6ca9693654c656f51d96c7aa286a39a84ef97ce32daa3af4ecdfe7869991c6f01d209d2e6acc331de86e19c90c378b9ff0051d4b038f49b2d6621aab0a8f983cc690b6a832c0bc3734073c219ea352205c92e4349be09158f0310db18bccc026ed1a683dfe10a79e0bd86b0c9fa2d2b1e2d14836831b57c2d03647278f69fac0ff116ea3161786b6d974f8a41f68775e00db41054df70e15ad6be145f1883fab9a55885037d6ddec690233a57b45ffa14b03f780cbfdd05159e5c20252c31e5939b6931d0010867bb8d48ecb4464da016c92c0b50e6615d782e6b7de10c6c54c3f6a82a07500dfdb98fbc43e3f4fcd2fc9889fd430c7f144d121cd9ae38ef1015f46b5066569f657ac7bc286a7ba04f852c33139f775c92411c989a0bc493842452b515ddc4eeac510fa5c17e4c9727d4e5ff00540e5e2a5b92b2de8e0d0a3020ebae5372294b8b41092bf51a453ed2d8f539a592cc0d4a9201075aab7180e0f6bcd9750e3385d41b4c02a2f5d1876defac0753f494d77419ba7fabd3edc8bfd177880931724c968ebc18061efd0f31197da3d0694e4b61e634a6f65897967bfd65fee8d0e1b152a754cb6a11a8a6565fea53a768b43a6232dce9c4111e5c9e7e9dd495a3d6878b32b8b39ae3b66e2f0a6b325129eda9cc87ef0b0ec3430986dac38d3cf03631d2d3147ceffa88a7da5d1ac2cfa9c991fdb97417e69ea9eea1e714e2eb632f74c564e95af568c7e271355a935e11051436bcfba9e4c5b63fa218997532c89ea05b2573f7a1bfe12d141271193aad5522c430f348be19be76453c17c3a26d1868de37fce18671fb408f7882a4c069e4410ca24da9e34f8c551cb17c3239f4f28f2ac8aeca456c62a9fac7ce916ad8605a808145a9cdd50375b7935869c0556aa7a94357601149fe5b924f8c726dc82c6944ac4956afe5fee144b14afbcd87e70498a7537e674fce23cc73be12e90f49b3c4017d7e1e1012611dcc32b00c6247d05fa25e8f7a1c39c4b8ebcfa15e2258bafe23d6eccb1d0443254b0a028000000006800b0039414084a543652ee760e7cd08ace745058f60158e0093fd24e9931aa73967fc4c6bf111d7fa7f8f1270139abeb2e41f7ce5f8131c430d8b2962b5ad2bcad5f0a8824e814acd7619ec2b7f3a1e1e7b41e6e144c46476a21dfa9b696e3f58abd9b8e499ea1cada656df434fbc2da6bc22d91fc34237a9e1f430a6e86d26734c7e0de5cc697734242daec371a0aea287531a4e8862e6cbcf2ce6008ce148a5d480695e208f08b3dacecaa5e585cea378d56fc2fc6dc633185dbe44d599309702d4500000820d012397840b84e6a91def8c1ecdff00a666de4ea3e60c79831e55d3bef4ed062be56d1761596a8169552c4b9a730b94023b4c3e7cc99405dd955ab4a012edc414a3d7b4c6c7f4c949dc98193ea508afb5166ca145663051c58851dc58c0df152ef405f9286a5f8335148b713154921b355528c69d6ca0936d4b5cd39c1db084d2a69da6fc05418bb1fd2f1c7920c9f5493e094b8b663d496ba56ed5a5aa4955ff002861c4b934332dbf2654ddbbed6bfcd1e4c28a667ae5b0b1eafc2bcf744fc1e14350e4ea8a934a016decfbf74571c18e1e8925d56497b2bd649273e4ec2feb579335cc485421bd65040d0d4d7c4537c19e64b5bb4e40fa650c5853b6946ec1688789dae80655964bb007d212b436d005a7c6b0d5fa44f29d6db2c65e0f4a02cc457aa6a472b69df131a5654524aab134ca68491c72a9249d628b158c9ae72d594500a0ead6a3420000f7c44972ea09b0394e9a9238ae9ba904a1262a59e2b85668a763e5a5540676dd5ea81f3f86e8ab9bb6675334bccb96c328ad06f398d4eb6e1118e1ce40ccc486254920eed14826e056b5e70f07290109528b96cd4153eb1d6a6a49dfbe0d625ef64f3ea64f8d7f227e1f6f4b98467191f4ce40c8dc33d0750d778b71a6e7e2f028ea33a6672c6856aa69c8917ec8cf3613321219169c75b5fd6037d61703b5664a012ce82f918f1d729d54f67818e3876fe2321994f523d8fd98d28e6dc0d994d1d7bc5c43f0bb69e59cb33f78bc57d71daba37750c5d61316268fdd1adaacbf6d7b452aebfcc3dd11e7ecc4980900235c660452bc481a4064c70c8aa487e3cb9313b83d1230cd2e729794e2dad3757da537103792575b731a18cecfc23cb21c9647ad9d4eedfd6dfa0b1d445860ba44c9d59e33023fea201e2f2f7f6af8478bd57d217303dce93eae9fdb32d11cef85c6ecd9388149d295ff009b471d8e3ade36834b5973143ca7520ef536af31f64f2b42aab0d47788f225e7c0ff005fd8f614b166463b687401d6ad85995dfe8e6754f73faa7bc08cbe2e5ce90f9274a746dd514af31b88ec31d9f0ee0c171be884a3e9f2197bc4c00af81dfd978a70f5d196a5a623274ce3f8ece1f87c45493626b5dc74d2a0eb12666281bb9af6dfc044de9061b033261fd503cbd6a6b54aff002a9eb01da633988c24d4bfaebc45cf7ef11e9c24ebf44538a4f8d85c4e2abea8a73df10483c6104f07976c38982a5e81dfb04dcc7841f0d8606e74dd0d44cc408b102d41a08c7523ea910e10d10e10908e71fa60c50f45264fb6e5c8e21453e2d1c91df4e0694fc5f48dd7e9471be931be8ebff4d1476549627e02308108b1d5728f79afbbe30f863ba622596ae873cc22a41a509a52dbab58bed97b69a61c8f4f48050136130703c1fe314253779dd5111263684546f1ca94a50c14f0c5c69830ced4ad1bd75adc68751bc6ef3fea33bb4b67096f9954758f81df161b1b1666640edd7205fdaf9562db6ae0c1f585b8f0f3f386e3c3d914272751df26567470558a16200b802b5ad85bba35586d9c2a588245b5a1635e16b441d89d1f6219850017a904f8d396fe512f1bb4664b97622d6345254d2c68596a776edfa98a2392bed449931b7f73e09b270556ad82ea4b9001edaeff00081e27158796699cb9b82a9a529b988a5f5aee8a2266bd5883a5770f01020874a5e1ab1b972c8a79bb1697f52c66edb636932d105aa480eff88e911310d3263062ec5a84d6b40bad81e71e972f8983228d21b1c4913cfa993e48a9294017635e16a6edc68441a5485bafaa4508bd790b1a8bf0b41a51bdec21ecf9865a8b9ad48afc7e905da27cb6364a85a162a4d7b2845aa290e475008146a917350695ad2bddbed0ec54bb0008a8a9b682c2809e35ac365559581f5b70035a534a1ec8d46b1f88c8cc5901a655cc090c336fb81436e5ba232956765b0eafdad01d056c72f65a9587b845a3cb60cd4b920d56d7a8ef3bb75784474984bb1a0cb42452c68ba934d6a2d7d4c73d055b24a4b72a3d22d500a020819696161cf9718858c9598924004684285a5ad6f99e113a42a15335c9ce01d32824d00450a0ad6b981d34b5e242ecf9b31ab948504025c85a03bf213d715e1a9b7180ef4b90963937f699a74792caf5398107aa68c2fa06bd1bc63452b6e8330a38ae6200700231069675a850c0fda5a69be2ea46084b0598aa33295ab302d94d895450154dac589a775cd87c1804baaacbeaf566380661de48e3f77c6279ce2dd9e863c73a4bfa9131b826ff00a4f2eaa2f6b861ed50dc1ef8aefd9566ba314406ccf75a56f937d7536af6c68062258162ced9475dc0eea2e9de73181623f786ac4b76936f36844faba55ecb71f45dcedf0514de8fd1c7ead3595a94799942ab13af541a30e5e31a144ca833b0b0eb353283cc8350be319ddabd269787aaa1f48feca9ea8feb6dddd78c56d8e904fc4da63f53722d9476fb5da620cb97bf93d3c5854168d86dae95c99755c3d1dfdaff00c63fcfbbc6301b4b69ce9af9a6bb3d34f647f4ae8205e8cfe50c333730afb8fe7122c514ed22bef6d53608b574bfb8c2a6288dff00231e7900dd4d7e3de202c4ef15f3e30e8bae016af90b384b99ebad0f1163f43df1067604add1aa38687c34306723f230169862985cb9279d2e03619328bea75fa43cb40526d75852f1d6a8e2d9f5988f3b50130333471af6403184bcb755ea965201e15148559d3826d59e67e2f13375cce54720a2a3baf10a62006806b727be94fee8998ac23e1e7b4a75a313463c40af5bbea07fa814d97535f36a123e11e845aedd1e64d372d95ecb70456f6f0bd4f3a2fbe236234f3bc4584e5ca14daa1a9e355fce2ba7ee15f3415f8471b09449f807fddab574afc6d1b4c16d059b2693075850352fc8353e3dd188d962b2c8e0df2062cf0f892a6b534de070faf38a631ee8a239cbb66ff99bde8f6348250d282c751eede3eb13b6a096c55f22ae4adcd3ba95dfda0eb68cbecc9f498a468686b4b539f7c6bf6ae1004f4868d419efd5514b9a514936ddbe279aed996425dd03158ec4198c663bea405eada82940a07ab68124edd53e105c6ed1904832e5977362cc28bc502a824586f3bf708ae9736b6b5ae69e7945789eb83c8ea61bbb2cb3d384395e21a5e0e8b142679d241b3c11180a69e78c094428a0d7dfd91de418ba0aef536b9df4ddba840f1ac3ddc1526629008a5729a9b71a589f0b7716c8c392689ea9de4e9a6a6f41ccf08b5fd489c8ad65ae50070a6f1c4dedaf214345ca6a3a6ca618e52da4514b0acb400d45286b7adef40d53626bdb1687661988ec452b9aaa01cf5190d141a52e4d89a1ee8bb4292981b06a64a2d09d080b4242d6ac7504d3c61a9857a9cc0c9946a09620cc6a93b94922bbeb12cb3bf45f0e937b647d9b870855cae42aaaa0b32b3934cb520faa77034d3489d2b0b3336750b25540fde30cecea49245c549ad34a0b981c912e48225adc93d77399bee8a516f5d070302470cc4d4d4ef6248f79f3489679d5b3d1c5d23a41cce496490a59c1f5de8dcea14581f13151336bacd2c3d228dcc4e66eeb0314bd3f9e512500e558b924034340052a05e9af7c61db6b4c4432d0e515b91eb1efdd0972722c8e38c3d1d1b1bb6a4c8073cd473b915fade0d4a0e66329b476fcd9f5198226995185c73606adee8c8b924926e78c2308e7850cf2345d8964ee23ba06d2bc88aa0e46848ec30ffd6e60fb6de31cfe1ff6179bf45b2be514500eecc406af1a56d4ecb9a577c05cd750a7eefd2915e31ae3783dc20cf8a6ca1a82feeede319c1af66534c7cc702f969cc311e15ac459b89ae96e7bcc01dcb1b9bc36b1d504b6c1737c23c4c218f1841ca0813d58f560ab27fd0f36f7c359c8d2dd9f5d6392947861462f947d54b04530210f53080cc87e90fa3de9657eb1292b3114d86ac8685876dabdd1c8e6ce34a8ad4baf851437ce3e8f17143a471afd20f470e1e7a4c96292a6386e4a454b03c06f10fc53d5326cb0df723298d3566dd61d9bcc56bd4ebb89f9c5862660cc6970c09ee16a53ef44077198d3bfc62864f1b25ec76b30ec3f11f289cd6d4d3e7ca2b764bddbb07cfeb13669b4558dfd888f32ff0091975b276884d771a83bb70a7b8469a6ed2189508d35911455829a54534b82ad50748e7d2e650d6bc6c7487fa4bddac4d081c38f0ff71c9453d9d8ca51d7a274f98998896a41adaa73151b85ac6d4bc4ac320f3f08aa91af026f6dc37c5de0e49a814b93651af6f3261d8c8ba97a0c8912156b12f0fb358be57aad8eea93c87d62f766ec40c0e6aad282a0d2c789b1a9e151a414f2c63cb24874d9323d22865e11ab42a7754538e9d9bcdf845bcbd8d46a3a6619430a3589e0cc3d5ade267a32184a952d58024e83aa456e073d2a49e512711855a049858aa9072ad09eb1b135b00341c8989b2750de96bfc9e861e852dbdbfec55cb7284224b2e5beca2d514efa30a860476f688b5c42cc75018896b5ddebba8cc08a1361400d79e97873e3d658a4b96a9535f5413a102bcf8d6224b5cc7311527534d47c87288e79d5e8f571748d2dbd06fd602d0ca9614801731eb1a0e6450137111e64d2e4927313af773df0b899d2e4a9698c1146998ebc4538c64b69f4bf55c32651fc470091d8a45bb4c4f2c8d9643145706971b8a95290b4d98101a501d4dad95753bc46476af4aa6355648c8b719cdde9c8683de628664c6762cec5df796352472ae9d9fee18abe1e6c61363d44838e726acc4b31de4d6bde60070e5998d4015d49a0f1899b45004e55f348a2c5666353c283b2190c9da04e1dc581c039f568dd86b017c2cc1aa378562ada5c164bcdd119b8d031fac3a3953f425e37f2497523504430c3d3193aa14b9eb581600df4a1245af63c218db49b4644274355a1f7183f2c4e7631a60f83477aa2a96df41bb89aee810c621d650af26a7ba91e69ea2aa3301be97af23c4471ca2d7275269879bb3dc1fb04f00ea4f85600f86983546f0f9c0814f6adbadee841329ea9a761f9c71c919458fa007ac68786ff00cbbe1f5e16f3c606d887a7ad5edbfc618ae6a6b4ee8094be038aae4367a44fc2495619a686a1f5427ac69ab7f48d2bc4c43c34acc6a7d51ef3c07d77087e2a71636d3c34b7701b873275263918ae646949f08fa80187a9885b3f1b2e74b5992983238aa9f7508d4107744a5309e020ca6226dad9898a92f2a60b30a57783b88e712961ea63a99c6ad51f36edec14cc3ce793301cc9502da8ea9047681156f4d45f7f8de3b67e943a35e9e57eb12d7f792c5c0d59378ed1ac7137514f1f898b232ee564928f6ba0db25a8e79a9f918b198d1558034983bfe062cd8c5389fda499d7df7fa075854a93402a4c78c5a6c2912de6a87248f6577f0158262cbad93b1cb2a50025855dec481b9554f13bcf0dd1a8c26ce12016623331002d8bb1a57b697af741124cc0009528a2d0d5dab6dc6a4834e42e7b22432ca450c499acc6b50c695cb4248df71cc5a0259296d9a387b9dd6c34967988c252ae7a819cd1802788de470bf642be1d15409d30bb5ea8bea9b1a1a8b5789ad6f4dd118e29dd401d45a5d506a473ddaeea7ba33fb5fa449289972d0b3a9f598d81af69246eaf6c4d2cbba45d0e9f5b34e932d44aa2d0120055a11fcc2fdfca29b6aedd9520e5399dec7283503b4d75e5f9441d9f89c762933a324a435bea79505cd6b5d78c62b1534e76d58824166adc824137b9bc29caf96531828fe28eadb2b1b2b10b991ae284a9b30dc6a38eef08abe90edf124be4207a35000d33cc7d071a22dce97758e7d85c54c96c4a4c656614a834b5aa3c7ceb00dad3ea42f0d7b77fbebee80c707296b80e6d463be41e336acc9ae5e6317274cc49cbfd3c21531aa750471de22134b200241a1151cc696848a5e28b12b2c917129d0e8c39711e31240aeebef1b8f31e79765008b8c359105684d58761a0a7f69b427261ed5698ec796dd342ce960ad0e9b8f08ab9d84ff5f31170e6b7a768fa79fca3b381a5f81842c6e4f439cd456ca7182cdd9c62cf0986ca2883c54dfbc7e50c6994d7ebee8b0c0e111c67646cbb8b3f59b98502c3bfeb14f6c70c77cfc92ce6e6e91031981575701729d695d180b30fe522dde38088389c30c8ce4559d8114d4928037bd98f745eed79e00cc147545d85e9c2bc2bca2a30f8939f2b0a117a1e7f0b188e7924ddd0aee712ba6e0722deeda1bd157f96bf69f881a7388a65708d16266a6f442c053f78a74dd4a036ec315f34ad7d403fa49f993f286c6da1b8f236b654fa38512e2c5a5023e7f5803caa6b0490e601579459ec6d8af3598b565cb50599d94d29ba95a5498d3f43ba3a728c54c5aa692c11a9f6c8de052839de350e436f8a3161bdb119325691cdb6becf3202d18323572b0de2c694aefb1aefb7088585c296ade91d03696c949942c335343bc6fb18cbe3f66cc4a0954237d6c47d7b61af0abb7c7c0af236a973f25c7427a52d849995ead21cf5d752a7db51c788de39d23b5e1a72baaba30656019581a860454107788f9a5265397646dfa0bd311866126737ee18d6a7ff00193f6bfa0ef1dfc6a9cb8efee47714dad33b3030e06032dc100820837041a820e841de2080c485613514378e19fa43e8d7ea988cf2c7eea6125782b13565f988ee20c56f48763a62f0ef25f78ea9deac3422198e74c56485a3e6d9669317b47d227b35fcfc37c44da98499226b4b9828e8d43dc751c888209c4b8541566200de6a4d07c62cc79124ec9678dc9aa254894ceeaa4d2a401a024936b4756c07ead85ffb793d6df31a8ccdb810e49b1d6968ceec7d812e51ab2e7982a333e83985dd63beb16c108d2fc2d5a0ec1c2b099e64f81b0e9dae4978ada1326d413d4b92b50056feb575b40b012c5d77835d78e97dfc077c22a79d39f1e711f17b625496eb3558ad945cd8ef1bb53ac4d3c95cb29863f845f484b56f41ddcb75b84627a73225fa40e8ca263533a72a59a837da21ed1e944d980a27eed6bbbd6dc41aeedda708a37627ac4f335e1bea7ce90b8e495eb437c6ab7b2560e6ba0ce8eead7068c472616f7774477146aee6d7b7f3f3ac1a43d0d3737c47d47c047a64bd5776ef3cbe9193fbac2ad0d9140093f62e0f335cbe173d8bce2a673d49313f1f332a2a6fd5bb4807e14f168aa063d1c50ed8906495b35980c3acdd9ce3282f2998a9de05988eca5632f58d7fe8ff0014b59d29d732ba03ad0daaa69dcc23253d32b329d54917e4690c5cd0b62a0a9f3d9f38b2c4375f2fb2aabdf4a9f7931030099a628e240f97cc410ceccecda86627b2a6ddd09cf2a8d0dc0ae562ed1c515966f46361bb5df00c1e3738a1f5be3cc4036c292169702a7b62a91a971685639f6bd0ec91be4d461a64b570662e65bf77034df4e11a29ae328ca41a8ad4105587107c231386c567143eb7c62760f68197d537426e386ea8fa728dd443bd772e4ee09462e9affd092b1dfbf69732b90b6722d4051756afd9ca3dc204865cc99556cc5ee6c7a86d53a53bf4bde0f8cc224c1990d730a546f1ad3c40af0a76c33058112d49e5735a777898954935fb0f2e06db97a19880f2eaac015ecaa91b997d93c40e315eec3769f0efde20d8fc7198c6b600d857b41279c4266022c846e3b264927a0eade78c69fa1bd1c38c9957149286ae78d3ec29e714fd1cd8f3315304b4adeee772af1ed8ed183c24b912d644a1455173c4ef24c714530a526b486e365ab2fa35a2a28a0a58281a4676510588b671a8dc47b4bcbe11376aed00064436de7898cbe2a754d6b422e083420f230d8cdc5d83e34d5179305a91518a4bde052b6d91d59a2bfcea2ff7937f68f089067a3dd583761d3b46a22a8658b44f2c6d33ffd9, 'image/jpeg', 'Replaced pool filter', 400007, NULL, NULL, 900004, '150.00', '2021-06-01'),
(500004, 300003, 'Maintenance', 'Completed', 0xffd8ffe000104a46494600010100000100010000ffdb0084000a0708151514181515151819181a1b191e1c1b1b1b201b1a1d1e1b1a1a23231c1b1d20202f24201d29231d1b253725292e303434341a23393f39323e2d323430010b0b0b100f101d12121e322924293232323232323032323232323232323232323232323232323232323232323232323232323232323232303232323232323232ffc000110800bb010d03012200021101031101ffc4001b00000203010101000000000000000000000405020306010007ffc4004110000201020404020705060505010101000102110003041221310541516122710613328191a1d142b1c1e1f0152352627292145382d2f11643a2b2c2332407ffc4001a010003010101010000000000000000000001020304000506ffc40023110002020202010501010000000000000000010211031221314104132251613271ffda000c03010002110311003f00c8daf5616d074425c39f58da1d4b232bc72e62369f2a5dc5516ddefdd390b032b6698200f0cc76e74c6f70d2b630e5ae292ed7158a15655cc148865df633aef3deba9e8cb1b881d8e4cdb88f674d7791bc6dd6b32a4eec0cce8bef71db33176d4f33dcc0f9d5c2e392095cdaea63c5313b835b2c358c3da56f5685d482aec41332080aac0cac824c8ed496de122e7abb6c6d266245cb913e1eeb31da22669d4d34288c390e19866f16a336a67fe2a188b8166350796bd37a77c6f832921ad3b365492d98306207d9f16837dcce874acfbb3c99df59d8d3c5a6ac63d6dc6583fae9a4545586a489dfb44f311ff15565313afd2bac6098323e134c71c201eb15afe17c473da7ce2d86050a84454771a2e4f0ef12499edad64d14790f2ab10ebb903990758e82926ad5019abc25a876b970359cc1995b31242e68ca20cf8a4c73d28c7c75a026c5dcee167c4bc96342c75812db7f11f3af70f07fc3e96b25b00856704dcb921b50208009771a01a73114bb852786e3dcb6fa29d4ae5b70a15617996f16a4e900e849a838a76296e0b1e8e596e4da794c8ca999330cc21900d8160dcfd9dba85c3382dc378aae5b96d7292d2b972bc19ca5b468532bb8813caabc5e26e5a66452dfbb7529723234ef2c4ebb68396e7a515e8e712b7683177ca5d8b1800ec3485e7398fd363544a8290cb1380b971fc59ca931eaeda9f0a28214024c043d2491344bfa26d72e23b916d40139878881fcb6ce51a69a115cb3e95db324fae2a0ead2a044800e50c20190351ce2985bf482d3206b42f9f105262d920efe105e49d77e5beb54b8c7c36728b7e46fc29b0f83b7ead1adb396cd98e50edaff000eac146c048e7bd15fb4ae3b926e193b0da349858d76d74aca62bd2cc0c95b983ba5b7259533ebb12d9f34911ce84bfc7ad3b235a1895b681c5c42559cac6c8f98903520c9d0318a7595af037b69f935589097173394653a66cc07fa736867946fad2fc4fa3168ab14945682cb981063b467039c031da962fa6786b7adbc33f41999411d403a90bce3acd757d3976f630eaa082433b98d3a78403f1a59646fc2068979607ff4abac0b4f6aeb2b66824aca90473046fdfeea55c4fd1dc4278bd53e9d3c7c84c649d3f5de8dc47a717d898b7694f32034ff00766d683c57a558ab832fad65074014049f78d7e7ca93cf43b4bec23d05b2cb8d4cc08f05c30743ec91a83b6f5a31c2d2f5cf5849ce1dc0d4c7850b2cc0e4c47c4d67bd09767c5996248b77353a9fb23527ceb67e8ddb259088073df324e9a2db1cf4fb468caf50e3fe84fc5ed82310d9ced74c40e79b7d7f0acd7a3d20391be551f171f4a77c66e116aee6b63c522644c9603301d2947a3e62db9ea517a6f9a9636a2ca667746a1ede5b2c0932544ee0498e511cfa93581c119ba4ff003b1ffcab77c4732e18980a254083eff78f3fcab07c3779ec4fc669b17f2c90fb87da6656b8a3525866d24011b099993b7523caa18676b6a737814ce593a10371df5fb43a1e502a7874840a490009227493333db5f99e4642ec53e72c49d34d769ca00000e4a0440d8523926da257e0331dc53d6dbcaa20e6198ed301fe5113e4290bb16624ebe7d87d053136c2db7869f1100aecda011f3f950ec916e7bec4763247bc531cb8174127ebca98dac031ea469044014192c09efbd33c0a7864c99ef34c3363c7b59ec37abdeddc0e12328554cc0851b9d18133a934cb18d29b92ef112d064edb6db81bc6b5db579d33332a92738390f89c01ae53a16200ea62455eeec028641130aa40ca20f351a96ec34ac52ccd3e41da13718c4036c80c56e1dc94d49531b830bce234de95db7b975c2e54d540885110413ed6879e84d35e318450417323720312549d412b3a2ea607ce74acfe0c3b33db2a189cd10097330748fb300993a695a62d38da0d1ee236c85d092b3ec9d09d06ba1df7d3b52724f2d7f5d3ad39b96f33e419898545014b12d1b30ee79cf2daabc370a60fe33055812a4651a6a412d004eda75d8d3274822dbd85ba83c4ada18dbcbeb5e5b0db15223791cfa57d0ddedb1272a9d248d8ce9cc7607f4452fbd875ba1b2daf57987818396048ca75274d872ebcea30f517fd2a153b326307285ccc0e9b6a7efdea8b7867660b6c3312465804b4fbb9cc57d1307c2ada2e5b92cade2cb2428d4822079edb517659574b61114080174e435dba0f90a94bd624da4ae8ee8031c6f95b6ae86e5cdde0808254019608332042e5de7799acfb5cbb67106da8255b2808e03aa66209211bc123c5a6835de44d3ebb8d2ecdead8b90351a05239f6ebbed526e136eeb87371908004cf8a02e9049d35333ce6843324ae4a85466b8f602e5a21ae021984b298caa7311a007449d07be953e776676506604edf0e5d056831fe8cace9784c9966f131d679b8eb553fa34204e20c49d3c24c9dceae074ad70945ae1955062cc322b3a400483e153e2cc57501946e3969d4d118be2d7d1822a1b397560c8273f865b2b081ecc0df49ea68ec3f024b6e1d310e186c4049ff00deaf7e0a8e65ae5d73ccf864ccf73d668ec83a3337999998b12ccd249dc9279d1dc3af0b41dae2b1c9063626488dff0051ad356f47d06a1ae8f288f3f60eb5d3c1932b062e73c4963ae8647fdbf2a1b2a0c71bb1062b1a97097f56aa491a22c2881a88102498331ce8ab632a6746320ec444cab4c83cb6f3d768a6a9e8fdb5fb0e76825d847900807c68b4b164bc1b6a99c059ccd90a8cb204ecde126647b5a1274a9cf2242ca2d18f76cec5a64f383ce9c70ce0ad7b0ec42657ce85198852c855bc2a188f09807376efa3cb1c0ecdb26e5bb79caeb96e30c8358248d3328d7b6dbd598acc47ab8610ab2640b7036007898820b00ccdc8e9a409bf509af881fe017a19827b58cba186d65e0eb0c0ba0913af5f81ad5700819090754c4130636b96c69a76aa381db20dc7b9987eee04b12b04a980bc9840049d7eea2f8298b6487ca56cdc3266066baf1d77c95a36da0994c5db329c659170ce031939607875f1031a0ed4170407d5c09d5c6dbf857afbe8cf48de30db28ccebb40d83720285e122113bbbff00f03eb457f2c395f23bf48f2ae1f48cd9b5333b23738f2e758ae1ab0a7fa7f5f7d6b3d2cc413620c7dadbca3f1acb6017c0deefbc7d28e2fe046307bf9963c5a9806353bc48de6ad5e1cbae72798d3513d86f34c706e45b0a2d03dc810341b12239d56b71149cc50b0d7f77e28e9ac47df5965376e911f3c1cbfc390db8590c0fb3cbda5d23b45097f83b68ca51b5900c8e5b11b7d68dbd8aca411b31d267b0dab986c5493a4f90d363a4f954e329f604d883118574d0ebd76a3f0aac1768f3fd694e71b8651a911a991d4831a76df5a5ec8800579244ee0f38e4076df9fbaaf0c8da3b6b45dc371f0c0c92604680750429237323f11cc33372e1b68ca8049fb39755273781869de0f41deb2b748b6c4a5c08bc831920cce931cc0abf0fc6022c00d735244cc6b20eab107bccfc6a73c2dfc9145063ac358501f32bb853ac0524968d3704cd64cbba33789d1a4c8f648d76209f0f9532c5718b8ec3c08ba01c84c08ea49314befb1f169aef3920ebcc96d0ccfcead8e3aa77e478aaecadaf13bb331e72fa9fed155dd240d07dff0089fc2a68f3cfe73f258a92e80c006370072ebe133f122a832647018c7660a211875300811c98c4ea7e34d309c596db81398402cb1e1049339753a7c37ec2b358b413980d0f90d7c86df126a57310095c808d0020c6e3983d0e9bf7a12c6a449ae4fa5637100db0e8480448204f3063699db4acc6238d3a9652c0b081d7ddbea3f2ae701c7ca9b4ecde2042fbf91e9f0a4fc6b0b76cbf8d596762401304eba69b4567c5e9e316d315219710e32a5505b2c8df6f2ca6baf2d2465204763bd0d638932c29695db5813a732359d46b349acdc3989227a8d3af71d62b47e8ff00067b8feb0ab0410cacb312d3ecee0c1d0cf4d6af2508c791aa8d3be4416edb80588d1d49df4833a4ccf5e5545d6b80eb9d66625989d3c9cd098dc62abbcb4155590c7316dc1235dc473e952b78e3753c51a1037f147f3665322b3e38b8f3e0783f05b9ae7f13c793c6bf1a85cb8c3763f07ff65431f8ccd7017875f0e85801e100c4e411249f8d1b770d6ae41536c66fe14217b111b0ed26aeada453640fea4c662563e3a6827ffcf6931e722ab600ac10220fb208d019924ace93bd117ac3060971f5202fb3035e60481ee02a6acb28a8c66083befe204139b9803dcde721aaec64d02d8c25d2a72db2da88395260827491ef93d239d3b4b652da9b81654001408c81614428d4b12069d4d20e218dbb6db323989dc310244f2dbac1a9d9c75c0035c2199a08cdeb1b29d21865d2741a77a8e5c5392fc2127b3a0a6e2a8b0a1c29d7c30073241258ee3f0d2ac5c6add05adac12609c8182ea24b1dcce9e15d44d21e2b8c76b880aa82c1750a554ea448cc262b4166c0540ae03b2cc6eabfda0893fcdbd05e9784d200cf0e5bf7ca72645b632e5d09926588d041236157f0d5fdddd950c3fc3ae9d99eff00be7e349bd1abc5ad620952a6104193a41d013ac69ee9a77863162e9d8fa9b4011ca73993aff37515a14758a895c4b96637d280a2d20ca4317d2736d0677d398a97094d2d4ed0c7e2e7e95cf4a67d5da198302ec6206e32eba13d4d15c1d0936947f973e52ce7f1a6ba81d939655e9a102daa811a77e6cbd4f6a4783016d927f8877e4d1f8537f4dcea8a0cfb3f7b1fc052dc21f028ca1a4c8076981f9d183f808fa0cc65df596c1cd1279923e006877dc9aa2d61df2822206e7308dcee41a758175648b84663000d676f772035ed46a61514e8172f3efef3bf5ac8e74ea8839519d4b770c6519f2c900652a6799f29277e545e03010d2e658ecab1a4f7fc76f3a3f138a65628be158d8080073046dcc72fb4a352d02c4585662097630239760076f9693b51b742b932376f866889d483a6933aefa44fbbf0071f846623244eb98981a98d0663cba0da75a2ad5ccc46604c6a0ce844e86762a60c7513b52ee237c290a5986ed2a264b723dc2843fea8e54d055c0108ad958206507a2ae683dcfe55659820e6623a66d27c82fe340bdf20c2991d840f75596afc799e9bfbcf4ad0d1b2c311a0ed035e5947d7e150b840209d67b127e2741f0aa59c9e7e6373affcd731033098f89249e5f1d68247130b03383046a2639473260f9015eba65fc409983d09db512bf87955e2dc28881997a47cccebe4050d7de1d27490248d76e733f7d142a28e2f662581582448fb5b6e64961ac8d72edb52fb533a6d4df176c6560221898276989102201df503b4eb4b6d61d84131af704ee771cbdf4c9f00ecb149d20ea28d38a6ba16ddc3cfda898ef037260efccd0af873119609235d49d09d87bf6ed52187b880120299d0fda207415dad8bc035db2a0c079ed041f9815aee03c782619d1ae12e8a7229d22584053324f381b0159fb56c1f6a35e793311ff981ff00357dae0972e78eda5c75eab689507a02091a509e2d9533ad3196388bb6cdc6b92e003aa824923624edce82e1f8aca472df5e93feada8c3c1b1457235bbd9075b6477e746e13855c0b9326239fb22daeb11bb213cc8de9638da5418ba0de1fc492e0c82d267218e676249651ed194f80274da87b3c4ef9553167500ff00f97bff008ababc3de42e4c49800006e5b5040d608f57da8ac3616d855536dcb0d08f58019063d9f57558df902a5d955bc7df72e4e47288a400beaf7622065df96fb55ed72f23a916ed6a5402ced07367111e6089e6474d682e23853e316540f0ae64b87346573ac9ca099cba418a862301781cc6daab1603c2dac99fe7395607b80a6ff47b473178abb74b8765ca1b45083283946d233733b9ab171f889444b998cc0528b94c293042a868d3911b55b6b00a0b2fac55208958263c0ba032647d2bb7aca29536ae07b8a6632900784c99f7d2c93ae0eb4518ebf7d8a5c7b769dd632136de46b235f59e5cb98a95fc6e2cb43b9b6ca0caa028353a482c679ebde85e2362e92acd946bb2c0ddb53a0eadf3a3b0d6ac0df34aaae60c188924f4e9b03b6dde8476ae58b6be863c16f39b17cbb97399356331a1da9a61d0a61af788924581a9de6dda31dbdb88ed41609adff877f56001984c4f88c0d7c47a530c4a05c3dc0019375244c1d2ddb120e9cc524fe8b63e6e8c4fa52496b40f473bf71d874a75c3532e48dfd5a4ff00688fbcfc690fa4447ad4014a909a83ce4b6bf08f8569f068336d30aa3e0aa3f0a4cbc4013eccdfa66c7d6a83cb2ffebf9d5186c29609e44ccc46b1235ed53f4a9b3623e3f20a2998c3285b035f15b931dd89fc69a3c412272e81d304148399c9f3efb49ebaed56e22ddc119ee68ba8197bf59d778d07e34dff00c229225bc2b122246b13cf5e55562459705730cc0c09d249103af5a938b6c8ab6c4e98b28d91f4d449ea4b687fd2ceede68bd2ace21c4d7d5a28f0bc1263916cc441ed957eea1b10a27c5a93ac882349d3e43e27b52d669dc4d3a8a7c8ce2bc8c1b1cee19a06a27a40d3411a000e681dcf5ae5bc600899c024af3527691b8d6600dfb77a1f87c2e7900ca91949de741eceba120fb8d5388b6c3280ba050371d4f48ebce7ce8a873c0290ad5258033a9dcc0f95759c1ebef3545dd1b511e664d5f6e20989f9d3b2cd91bb732e87dd1a0a835ccd1e5da3dd51b9313008f398f81aad1490773024c0d875a3406c30de3b570de3207ce86b4f3a73a29b09752e046439c89022641e60ed1df6a142324e72219325b61d2bd81e1f76f6a3c29cd8edeeeb4c2cf0e4401f1064f24dc7e7f754719c459f4f653928fc7e9558c2bb16fe8b435bb4325bf11e6edafc3f5f1a16e78bb93b9a822934d387e0334337b3c8736fcaa9aa4846fc221c2f856732f393e049e82b42f71b28b608c8bb05e5e5fad68723e1f2f776fbebb94f2993f1ff009fb8524b9291b45a1da67372f3fbc6f5dcf97e93234f2e9b799aaf2f2fd69b9f21b545d7ebf41ef34350eccb9b1039a8fa797ba0501731eea5b2c892149d34f13311f3ab5ad9dbddf89aa1ac6e7ae63f4f950d521b629c4713688f5683f76cb23daf13299df791d7ad12fc599b2933a191f3fc09aa6e607c88d07dd5e4c1f2fea1f3a5710d90c3629cdc5592035cd4e84805b589f7f5ad29e00aaf999ee0ff005272ff00474fc6b3b630b1710ff3298f78fd7beb66f804b899f2827336e4ee18f29a49ba6520ac5c783d87ff00bafa69ed269a8eddaa47805924fef2e133c997b745ec288382b7008b6b07f40fe14458b2910aa246dacfdf53726ba63a82067c00b3619573952f32daeb1d479511c4a1b0f22486bef041f1082ca396c729ab31365ae5b2aa32eb26167901b480769a55c656ee544172002ec4845d5dddd8e866000c001da9af6a47456b6ccbf174cd8aca3342a09cd3a4007a4c6bf3ad1f0dc4ab93b8275ca4ea3c88f68527c4e1ee160c6e172011242a98267eca8e7d66bb6c991c8f23b4fd1aacf1a71a645c93607e9101fe274e93f163f4a7ee8819037842d9b6337207a79c0acf71539f164488cb6c49d869324fbeb5b670beb1dee2b67d620090a04c798220cc524d7c42d26e8031259754b88e0cc8061b51d0f703e7426070c19d19e00cc3c24c6df70d3fe29c3291caa2e8970fef00d39ecdf9d678ca82f152e05d6ed4b66001df6e703583bf51343622da3100f8778ca60799313e7229cd8e1d70386b6ace23f876d3e1a8fb850adc1f144922cb436e65247c5bdae53efa749f820e2c5787b6d87b85c0cc0290adcbc5a489044c123f3aa2ea0d1880730e640dba0d60530c470ac4a2806d3851ae90c07c0d06c9a010640d67433e46ad1fa1a284789c3c8fb33cfc4a0fdf26ba96c11076ebace8361ac7c6872d244eb9a26341bf6dab8d7c66206836899a56b8034e8a714ab9a114ae9d743dcf9d0ea0f5028dff000ecee1514b4eb1c80ee79538c2f0bb7687acb90c797300f61ccf7aac236739242cc07057b90c7c29d799fe91f8d387c5dbb4b92d0cc408cc4cc7bf9f96d4363788b5cd07857a733e67f0a5fbe82aa95742be7b2576eb3192492799aea5be66aeb7663ce9b60787c43dc1fd2bf89a6a4b9623937c22180c0480cfb725e67cfb5358d3f5af61dba9ae0ea7fe7b0af013a9f87ff2291bb1a31a3a83f2e9e7e4390a9a24ed3e7d075f335c0396fd7fda2ac4ce34da77daba2ac32747150f4fbb61b0ae9b6da69dcebcf90f21f80af1f59a6a3bedf4fd454905cd248efb7d29a97d31367f8577148d3981f36fd7cea2ebbffa47ebe22adb6b9882cc35f119e836d8775f857552488d73318e5b4c6fd80a9b68b2453977fea5ff00e6ae5b710647b5d75d47e744af0e72b232fb7d7a347e1524c0bc31c8a6186c64ecbcb6a9b9a29a306b2cc97154aa6af9496504c31e448d3953bc3369ac6b27e7f9d096f021de56dc10c8c4178236e597f97ad1386fff00207a47d3eb59f2493a2d8d3468fd1ae1d87ba1b3cbb03aa130a01d8c0df9d6bece1913d8455f20057cff00d1dbc5312873429ccad3a02a5675f7853eead862b8f5946cbeb127fa87d6a98daa2734ec6d546270c8e32ba2b83c99430f9d287f48ec85243a9ed23eb415af4995a58b00a1a3523a0fce9ec4a62af4a3d0f5406f619498d5edea74ea9ce47f0fc3a1c536159816016239902479135f55c27a4369bed8f8f78accfa4dc32d13fe230ef6c063fbc495dcfdb51f78f7f5a78cfc0ae07cdeca1172e33a300d1e290440006a398efca98e16f3db21ad9208e9f8751da98f10c3850a0133dcc9fba95b61f28d248fe1fc50f23dbf45dc6d036e475631e2eb0f58c013cc8f0cf78d7df46b5f368eb6d2393004cf913ad65834f881f7fe0ddff5da9bf0ce32f6fc0c03a7346da3b7ea2a5ed25d0fb334d83e221f9d106e1a5d80c35ab84dcb17239b5b6dc7976f977aa717c5d1495d646e0833a76a5aa0aa7d0dd5eb19c6a5efdc239347c001f851ff00b5d7a9dc72ed3f8529b972493cc924fbe8c4e6a8c1da688e71f39e94d786f086cf26729e4443191d0131f1f7537c0f005b2b9ee0283fccb808f722f33d86b5462b1f9814b6b9579b7db6f333e11d87bc9aaa825d91726fa2b6ba96814400b73f3fe63ccd2dbf7198cb1935732450c5731aa242ec97443292605136ad454ada46d5a2e17c1c652eeea08023556dfb6691dcd1935156c449c9d203c1e102c33896e4bd3f3fba8e1cc93e647dcbfafc88b98740405793f698ba01e4a27f1ab1f8792032ba281ec8ceba7f31863ad4659176cb2857008e41db4d3fb47d6bafa01046bb0e6a3a91fae5de982616c0196e5c058099563e23f088f76beeaa2f5bb248fde0d77df403900175e93de696334dd0d2852b29b60c4af90907de741b77f3ab40f1433c803da546227a0d07e88a293158698379d3480554913e500c55ec98675118a3d7ff00c8efdf49ab75e495df800b6d6a1731793bf8341a1fc63e7553b8980fa131252207fc49a676aee1ed99660e3fa5d4fd2afc4f18c38cbead341321967a44103cfe3492935cdb1a09375484ed7957334db600408f6b693b798f854038945e8b1a6bd07d69b3f11c3bac32982649553cda6223a695c7c4e119a4a5c8802008ebdfcaa3b9a3403b58639562757246b95bda3ca75f8513eb8a87011c7604c1f00d76eddaaaff0013650228f5a554cebcb7dbc5452f18b609f03990390e53fcdfa8a9b63a2abf6cb1045cba17299d09d8ec0e9a6a68cc00fdd8026351af49204d53fb7502a8f56e4ac6ba09d23afbea786c58b96d9d54ac1883db5fc6a3329145c827979febf5b523c670cc535c22c15cb00c65cc44cf413cbe54f0b78b4fb4247ebf5bd3bf45b1feaeee43ecbc03d43098f76e3e1471be793a7c2b467703e86f11712c6d2ff5c8e5d06a3e145ffd138fdbd661c6bfcc7dfac57d414d76b569121bc8f95b7a0fc4795db03c81fc685c6fff00e7f8fb8b0ce8639068008e6040afaf5709aed5215c9b3e2f89e1189b2a0622db0cbb5c03329f361f8eb41c0234afb8bac8af9c7a61e8f7aa3ebed2c213e351b24fda03929e639796d684fc32528f931ef87075072b77f65bb37d7fe2a92bb8d88dd798ee08dc77e7f2a6100d0d7ec86ec46c46e3f2ed4cd582322ab389642181208d986847ebe15a1b58bb38a50988f0bc6971743eff00a1d3cab319bc595bc2fc8fd96f2e87b7df5d920ed94f4fc47ea3caa728d8ff00a39c7fa36f6bc59dd934f10208f2619647c63bd7130822abc1715b86db5acc7298907941074e9ac50bc7788fa916c4ef9be596a6a2e23db62cc5dfb97dbd65c72dd27603a28e428778034abeebd06c64d6a51a3139b652de2a92255c895722444ea49daaaa344dc8a56d99000d4ec3af9539b3c3ef227ac370293f64004fbf48f751583e1c6d78c80ce468a44e5ede75db9c56f19b6caab9b4dbc507781f8d2cd268559249fc403d5b1dd8ff00e3f4ab116e0d03b47bbe95e2f1b9ae7f88fe6a97b71fa1d6597d9e366e3b2a82ccc480a04492761b56ad3d06b700bdfb99e066cb962635891b52bf4731f6ad335db8acec34488812353af38d3e34fcfa5b6ced69fe2b49254f8346395af9314623d0af1786e5c65eb2a0fbb4d7e554e27d10f5485bd65c27a03f7c2c0f8d3c3e9627f92ffdc3e95eff00aa87f90dfde3fdb42e43fc45fc2bd1ec2ddd1ae5f56d247ace7fda2b3fc4f0d696f3adb6764530a59c931d67b9d6b5d7bd255652061e1a0e562d30c4687d8d6b2984272891af953e386cf923966a2b8064c32fe89a98c2af4f99a2cd8b858c23472d0c7dd5dc8ca7c56dbe068b8d12591bf20a30a9d054c6153f84516af70fb2be472927e3526c3dcfe063d6857e077fd033854fe11f0a63c04055748819d4f6f1033ffad41ac5cfb2ac3b472a2b056ca219041cd3a88a9e58dc596c192a4b92d9803f9491f03ff1526ea247391caa6ebbf7d7e22abb7a8f2ac1167a8cfa1fa398cf5b611a65868dd986fe53bc742299dcb8177358af47b8d5ac3db65724333cec488cabafdf415cf4959ae33b16f640400683724ea46bb0ad6a6a8cce0edd1b8b98e036aaadf10cc4c0240e7cbf5bfc2b08dc67365597d4f8998ed2760018803b1fadb8ae3ca10adb04972331982154401ecf524d0dd7d83466ec6397afe3526657041820ee397bebe7a9c6c48fdd912c0b1ce4e80680683f44f6a6185f48edcf8b381a4683e260f951d91da3147a53c07fc33facb63f72e7fb18fd9f23cbe1d251b6b5f464e2b62fa9b45959581055fc3981e4260cf957cfb88614d8bef618939754277643307cc6a0ff0049ad18e77c109c6802fd90c083fafce806629e1b925793f35feaeddfe34d9c03543203a113da99c6c58c9a2ac31cadac19883d45673d36c467bc8bfc283e2c49fa5392810c2cc743cbcbb524bd66e5dbd759412240d013ec88e5e5536b92c9879335dcb5d54abed69a88d3998815b23130499c099449a79c1b0254fad6425fec8234511bebcfeea9f05e1b9c8bd7069ba29d675f68f6e94ff352c9d116ec0f0d88b85bc4903ad15ead667289eb1ad766bcc241131e5bd4c1603c4f87b5c832800ea351e46a9c0704b57dfd5a8809abdc064ff6c4493b791e95d380767c896a49d9d98b13f3d2b67c2b860b1685b0496dddb9b3733e436149396a8be286cf915d9f456d2800dc761fe9fc050e7d0ac3924fadbda92625749e5ecd69c83d2a041a8b9335a845748cd1f42b0ffe65e3fea5ff00654ecfa0b863bbdefee4ff006568b21a22cd92398f8d0d98daa307e91700b184086d172ec4ce62080a3b051a93f71aa6fe2b43a2c4721ad59e96e33d6624af24103ddf9e6a54f8d0c088deb5618b68c59eb6a44d31400905a7cc8f9d1563196d164de70c7f959a3e222958715eb8411559c2fa229d1a7b456e5b533981120c6527dd52b39c482d239758ef5570e27d5208d917eea31275e915139b219ebb78ca572a404a9f2fba964ad5062e9d82aecb550f688eb56db329d08331fd426abbc359af29f0e8fa18bb499175cc222b2ffb02fe694b8554cc7ef088d7623a8db6ad7b2820133314d7867a38f7533adc555724c104904120fc6263ceab16df424abc985b5c071130716408046e75e635e9a6bdeaf3c0eee9ff00f5b6faf806dd77debe876fd0cdb35e3a107c2b1f327ddb51f6fd12b0372ede6d1f70a77093fa1378a3e5c782dcd8e2ee4f6551505e08e77c5dd9f211f235f5affa5b0b00643a7f337d6a2de8ae17f818793b7d68e923bdd89f291c0ee8d3fc53329820904303d0c36d54627816259c39bc1c8112ccc5a049004edafdf5f5a3e89e1e23c607f57e55537a1d6b95cb83fb4fff0034529ae85da0cf95dbb84e8da38dc6db76e47b54e3b56f7897a00b70e64bc55c732920f9c30f8d64b8cf07bf85205c00a9d05c5d50fe20f63ee9ad58e6df0ccd382be04b8bc107d54e571b37e0473149b03c32fa66fde6493c8133bef07f535a4cf222a9611ca99c4552685a8635a6fc1786fac02e5d816d4f841d33904eff00ca3e7b50fc23871bcd2da5b53a9fe23fc23f134ff19c352e402cc1400028d84721dab43952a303761ab795bd96063a1a90a1f0d844b6210769abc54980ecd76b9576070e6e301c86a48e9f5a56e8e516dd228bc8591941824100cf3a438fb6f65559c9604c785898313acc56dff665bfe27f97d2a9c5f02b371323b3c483a113a7fa691ce2cd50c738f060ff0068a7f0bfc47d6b9fb453f81fe23eb5b05f43f0bfc577fb97fd95dffa430dd6eff78ff6d2ec8ae9231dfb453fcb7f88a926315982846049de456d2dfa1b853cee7f78ff006d2ef4878161f0c88d6b3e72e233348ca22748ee2b94930eb24acf603056ded82e809d413af23e7d2a4fc26c0ffb63e27eb40d9c65cb6b956224ee277a1ef719bd988f069a7b3f9d5e0a55c18a5cb1a7eccb3fe58f9fd6a5fb3acff96bf3a4ff00b62f754fedfcea2fc62f0e69fda29f590b46842000000003403a015cae5862d6d18fb45549e5a902a46a6d00f454ad9a84d750d0a38a2da4165ed23dc7f335071a7baafb9a383de0f91d3f1aa1872e9f857979a35367bbe9a5b634c825f0abaceff7fe85693d0fe2a039b0cda34949e4dcc0f31afbbbd6650788a9d88fa7ebdd5d322082411a82370473a109eaecb4a1b2a3eb20d4e96705c77aeb28fcc886fea1a1f9fdf4c54d6c4cc6d5704ab86bb5ea6011ae8af4570d038f1a0b88e092edb6b771432b0823e87911bcd19516ae38f8ef1ee0af84b994cb234e47ebfcadd187cf71ce170afb3710c0dbbd6daddc50cadb83f220f223ad7cbf8e7a3f7f0d732db0d711a4a9512447268e63af3aac677d892897601c7ab0153228d00edd688a8a9a90ab1e59d5ae8ae035d140e3d13006a4e94fb0b605b4cbcf763dff002a5780bf66db1372ea2b7252c01d79d1ff00b530ff00e727f70a8cddf06cc18e96cc24d742d05fb530fcaf27f7548716c3f3bc9f1a99a6c2808a92d05fb5f0dfe727cfe95e1c630c3fef27cfe94299d6364ac3fa638ccf7c24e890bef1a9f998ff004d699bd20c3a827d6a9201300193a6c34acc58e1a9740bb719b3392c6088d589e629f1ae49e59d440d9b5a5a4ea6779335a53c22dcfb4e3de3e942fec1b7a9ceff0011fedad7192461b13022b979b4a76381dbfe37f88ff6d71b815ae6ce7de3fdb4dba1465647813fa57ff515daf288000e400f857a6a403c2b80d76bd4282578b1a0eff84fd2a37379ea037c77a9e314941977047de27e53557d95f7afd2bcff0056be499eb7a195c5a07b9a30edf5abee8d7b1d6aab827e1a7bb7fd76a92b78476acc99e8570687d0ac664b8f649d1fc4bfd406bf11ff00ad6d56be5983c4fabb8973f81949f29d7e535f510c348320ebe735ab1bb89932af95968af4d44bd56f7a2ad648b66b99aa817bb579af0ae38ba6a04d562e8af1b83ad0389cd54c2b8d705566e5038f9cab54830a8454956b55983db44f357948af05af05aeb06880f1dc345c70f9f2e91b4cea7bf7a598bb1ea9f27b420107699ed5a155aa38c6194898d94f33d4d2b765a0fc08c1fe5f9fe55d9fe5f9fe54b56eb46e6bdeb9ba9a5a1c643cbe7f957437f2fcff002a5deb4f5a80bcdd4d751c3644cc0ce91d0d32c27135b76d51958913b46d27bd66ac621b5d4d5cb7d8f3f90a68a27257d9a53c6adc7b0ff2fad51738ddb51251fe5f5a5785199d41d64c7cc5696ef04b07fedffe4df5aa7427b680b01c552eb32aab0813ac75ec68e2c2bb638559b458a244a8fb4c79f7352c83a52b60f6d10cc2bd985482d7596859ded22018578b8ab320e95122bacef6d112411154b268c39833f0fcaafa8afb47ddf7d64f53cc4d9e8d54a815b9fc47dff95548f135d4d8f9fe3504dff5deb123d42c2bb8ad9fa2dc43d65a5427c48729eb948254fca3dd58b4d87ba9c7a25a620f746f941abe375223955c4dd3dce9ad0ab998f41155710c432adc20c4293b0fe1acd61388dd37147ac68d34f855eccc91aac43adb04b301a733140e2b1ab0b17142b44756d63c3d41acff0014d5589d49720ceb22408d79567f88716bc6e37ef088000801606ba080283632859b8bbc5c2dc7b696cb948048d141807c4c600dc77a1edf11687b97005404e5819a428dc1e933f0ac559c6380c037b449320124903593ad56714e5541698a572a1bdb36a9c46e900956f6431d362d3020eba54ff69bf311e620d61ece29c66f16f56d8e21763daf90fa572958743fffd9, 'image/jpeg', 'Installed water pump', 400009, 400010, NULL, 900008, '250.00', '2021-06-01'),
(500005, 300004, 'Cleaning', 'Completed', NULL, '', '', 400007, 400005, 400006, 900014, '0.00', '2021-06-03'),
(500006, 300005, 'Cleaning', 'Completed', NULL, '', '', 400007, 400010, NULL, 900015, '0.00', '2021-06-04'),
(500007, 300006, 'Cleaning', 'Completed', NULL, '', '', 400004, NULL, NULL, 900015, '0.00', '2021-06-07'),
(500008, 300008, 'Cleaning', 'Completed', NULL, '', '', 400009, 400006, NULL, 900014, '0.00', '2021-06-09'),
(500009, 300004, 'Maintenance', 'Pending', NULL, '', 'To be added by staff', 400007, 400005, 400010, 900003, '250.00', '2021-06-21'),
(500010, 300004, 'Cleaning', 'Completed', NULL, '', '', 400007, 400005, 400006, 900014, '0.00', '2021-06-10'),
(500011, 300009, 'Cleaning', 'Completed', NULL, '', '', 400004, 400010, NULL, 900015, '0.00', '2021-06-10'),
(500012, 300005, 'Cleaning', 'Completed', NULL, '', '', 400007, 400010, NULL, 900015, '0.00', '2021-06-18'),
(500013, 300008, 'Cleaning', 'Pending', NULL, '', '', 400009, 400006, NULL, 900014, '0.00', '2021-07-09'),
(500014, 300009, 'Cleaning', 'Pending', NULL, '', '', 400004, 400010, NULL, 900015, '0.00', '2021-07-09'),
(500015, 300001, 'Maintenance', 'Pending', NULL, '', 'To be added by staff', 400004, 400006, NULL, 900013, '100.00', '2021-07-03'),
(500016, 300004, 'Cleaning', 'Completed', NULL, '', '', 400007, 400005, 400010, 900014, '0.00', '2021-06-17');

-- --------------------------------------------------------

--
-- Table structure for table `jobs_history`
--

CREATE TABLE `jobs_history` (
  `EmpID` int(10) NOT NULL,
  `JobID` int(10) NOT NULL,
  `DateWorked` date NOT NULL,
  `HoursWorked` int(11) NOT NULL,
  `HourlyPayRate` decimal(10,0) NOT NULL,
  `TotalPay` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`Username`),
  ADD UNIQUE KEY `Email` (`Email`),
  ADD KEY `ACCOUNT_FK1` (`EmpID`);

--
-- Indexes for table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`ClientID`),
  ADD UNIQUE KEY `ClientEmail` (`ClientEmail`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EmpID`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`ItemCode`);

--
-- Indexes for table `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`JobID`),
  ADD KEY `JOBS_FK2` (`EmpID`),
  ADD KEY `JOBS_FK1` (`ClientID`),
  ADD KEY `JOBS_FK2.1` (`SupEmpID`),
  ADD KEY `JOBS_FK2.2` (`SupEmpID2`),
  ADD KEY `JOBS_FK3` (`ItemCode`);

--
-- Indexes for table `jobs_history`
--
ALTER TABLE `jobs_history`
  ADD PRIMARY KEY (`EmpID`,`JobID`),
  ADD KEY `EmpID` (`EmpID`),
  ADD KEY `JobID` (`JobID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `jobs`
--
ALTER TABLE `jobs`
  MODIFY `JobID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5000023;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `ACCOUNT_FK1` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmpID`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Constraints for table `jobs`
--
ALTER TABLE `jobs`
  ADD CONSTRAINT `JOBS_FK1` FOREIGN KEY (`ClientID`) REFERENCES `client` (`ClientID`) ON DELETE SET NULL ON UPDATE SET NULL,
  ADD CONSTRAINT `JOBS_FK2` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmpID`) ON DELETE SET NULL ON UPDATE SET NULL,
  ADD CONSTRAINT `JOBS_FK2.1` FOREIGN KEY (`SupEmpID`) REFERENCES `employee` (`EmpID`) ON DELETE SET NULL ON UPDATE SET NULL,
  ADD CONSTRAINT `JOBS_FK2.2` FOREIGN KEY (`SupEmpID2`) REFERENCES `employee` (`EmpID`) ON DELETE SET NULL ON UPDATE SET NULL,
  ADD CONSTRAINT `JOBS_FK3` FOREIGN KEY (`ItemCode`) REFERENCES `inventory` (`ItemCode`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Constraints for table `jobs_history`
--
ALTER TABLE `jobs_history`
  ADD CONSTRAINT `jobs_history_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmpID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `jobs_history_ibfk_2` FOREIGN KEY (`JobID`) REFERENCES `jobs` (`JobID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
