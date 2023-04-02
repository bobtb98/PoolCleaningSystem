<?php
if (isset($_GET['username'])) {  
    // get data
    $username = $_GET['username'];

    //connect to phpmyadmin MySQL Database
    if ($connect = mysqli_connect("localhost", "root", null, "sdm") ) {
            // if update query is sucessful
            if ($result = mysqli_query($connect, "UPDATE account set AccountStatus = 'Locked' where Username='$username'")) {
            }
            // if update query is unsucessful
            else{
            }
        //Close the MySQL database connection
        mysqli_close($connect);
    }
    else { die('Could not connect: ' . mysqli_error($connect)); }
}
?>
