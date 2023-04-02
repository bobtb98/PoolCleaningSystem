<?php
session_start();
if (isset($_GET['password']) && isset($_GET['username'])) {  
    // get data
    $username = $_GET['username'];
    $password = $_GET['password'];

    //connect to phpmyadmin MySQL Database
    if ($connect = mysqli_connect("localhost", "root", null, "sdm") ) {
        // run query 
        if ($result = mysqli_query($connect, "SELECT * FROM account where Username='$username' and Password='$password'")) {
            $isloginSuccesful;                
            // if query return one result
            if (mysqli_num_rows($result) == 1) {
                $isloginSuccesful = true;
                // for every execution, system fetches one record row from left to right and stored in row as array. 
                while($row = mysqli_fetch_assoc($result)) {
                $_SESSION['Username']=$row['Username'];
                $_SESSION['EmpID']=$row['EmpID'];
                $_SESSION['Role']=$row['Role'];
                $_SESSION['Email']=$row['Email'];
                $_SESSION['AccountStatus']=$row['AccountStatus'];
                $_SESSION['SecretQuestion'] = $row['SecretQuestion'];
                $_SESSION['Answer']=$row['Answer'];
                }
            }
            // if query returns no result
            else{
                // go back login screen , notify user of invalid username/password.     
                $isloginSuccesful = false;
            }
                //convert php data type into JSON. Then JSON into JS datatype/ object(in index.js)
                echo json_encode($isloginSuccesful); 
            }
            //Close the MySQL database connection
            mysqli_close($connect);
        } else { die('Could not connect: ' . mysqli_error($connect)); }
    }