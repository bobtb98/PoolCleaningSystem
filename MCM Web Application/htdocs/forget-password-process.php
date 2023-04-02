<?php

session_start();
//variable strings for mysql connection
$servername = "localhost";
$username = "root";
$password = "";
$db = "sdm";
//connection to mysql db
$conn = mysqli_connect($servername, $username, $password,$db);

$user = $_SESSION['Username'];
$_SESSION['SQAnswer'] = $_POST['SQAnswer'];
$answer = $_POST['SQAnswer'];

$sql = "SELECT * FROM account WHERE Username='$user' and Answer='$answer'";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
    while($row = mysqli_fetch_assoc($result)) {
        if ($row['Username'] == $user && $row['Answer'] == $answer ){
            if(isset($_SESSION['error'])) {
                unset($_SESSION['error']);
            }
            echo "<script> window.location.href = 'reset-password.php' </script>";
        }
    }
}else{
    $_SESSION['error']="Answer is incorrect.";
    echo "<script type=\"text/javascript\">location.href = '/forget-password.php';</script>";
}


?>