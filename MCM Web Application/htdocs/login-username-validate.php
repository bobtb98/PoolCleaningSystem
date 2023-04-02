<?php
session_start();
//check if data is transfered from login-username.js 
if (isset($_GET['username'])) {  

    //get data
    $username = $_GET['username'];

        //connect to phpmyadmin MySQL Database
        if ($connect = mysqli_connect("localhost", "root", null, "sdm") ) {
            // run query 
            if ($result = mysqli_query($connect, "SELECT * FROM account where Username='$username'")) {
                $data = array();
                // if query return one or more results
                if (mysqli_num_rows($result) > 0) {
                    // fetch data queried and transfer into array $row
                    while($row = mysqli_fetch_assoc($result)) {
                        // When username user input matches with username data in database
                        if ($row['Username'] == $username){
                            $data[] = true;
                            $data[] = $row['Username'];
                            $data[] = $row['AccountStatus'];
                            $data[] = $row['Role'];
                            //to retreive username and  secret question when user forget password
                            $_SESSION['Username'] = $row['Username'];
                            $_SESSION['SecretQuestion'] = $row['SecretQuestion'];
                            $_SESSION['Answer'] = $row['Answer'];
                        }
                    }
                }
                // if query returns no result
                else{
                    $data[] = false;
                }

                //convert php data type into JSON. Then JSON into JS datatype/ object(in index.js)
                echo json_encode($data); 
            }
            
    //Close the MySQL database connection
        mysqli_close($connect);
    } else { die('Could not connect: ' . mysqli_error($connect)); }
}
?>