<?php
session_start();

$user = $_SESSION['Username'];
$answer = $_SESSION['SQAnswer'];

$newpassword1 = $_POST['newpassword'];
$newpassword2 = $_POST['confirmnewpassword'];

//if password matches
if ($newpassword1 == $newpassword2) {
    //variable strings for mysql connection
    $servername = "localhost";
    $username = "root";
    $password = "";
    $db = "sdm";

    //connection to mysql db
    $conn = mysqli_connect($servername, $username, $password,$db);

    //run query against database
    $sql = "UPDATE account SET Password='$newpassword1' WHERE Username='$user' and Answer='$answer'";
    $result = mysqli_query($conn, $sql);

    // if query return result(success)
    if (mysqli_affected_rows($conn) > 0) {
        echo "<script>alert('Password sucessfully changed!') </script>";
        echo "<script> window.location.href = 'logout.php' </script>";
    }
}
//if password not matches
else {
    $_SESSION['error1']="Both passwords must be the same. Please try again.";
    echo "<script type=\"text/javascript\">location.href = '/reset-password.php';</script>";
}

?>