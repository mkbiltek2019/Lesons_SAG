<?php

$global_phpunit_request_start = true;

function getLocation($_path) {
  global $system_delimiter;
  $result = $_path;
  $path = str_replace("\\", "/", $_path);
  $path_s = explode("/", $path);
  $path_count = count($path_s);
  global $serverToClientMappings;
  foreach ($serverToClientMappings as $serverPath => $clientPath) {
    if ($serverPath == null ||
        $clientPath == null ||
        $serverPath == "" ||
        $clientPath == "") {
      continue;
    }
    // check is serverPath is parent to path
    $serverPath_s = explode("/", $serverPath);
    $serverPath_count = count($serverPath_s);

    if ($path_count < $serverPath_count) {
      continue;
    }

    $isParent = true;
    for ($i = 0; $i < $serverPath_count; $i++) {
      if (strcmp($path_s[$i], $serverPath_s[$i]) != 0) {
        $isParent = false;
        break;
      }
    }
    if (!$isParent) {
      continue;
    }
    $result = "";

    // construct client path
    $clientPath_s = explode("/", $clientPath);
    for ($i = 0; $i < count($clientPath_s); $i++) {
      $result .= $clientPath_s[$i] . $system_delimiter;
    }
    for ($i = count($serverPath_s); $i < $path_count; $i++) {
      $result .= $path_s[$i];
      if ($i < $path_count - 1) {
        $result .= $system_delimiter;
      }
    }
  }
  return $result;
}


function getErrorMessage($errno) {
  switch($errno) {
      case E_ERROR:
          return "E_ERROR";
      case E_WARNING:
          return "E_WARNING";
      case E_PARSE:
          return "E_PARSE";
      case E_NOTICE:
          return "E_NOTICE";
      case E_CORE_ERROR:
          return "E_CORE_ERROR";
      case E_CORE_WARNING:
          return "E_CORE_WARNING";
      case E_COMPILE_ERROR:
          return "E_COMPILE_ERROR";
      case E_COMPILE_WARNING:
          return "E_COMPILE_WARNING";
      case E_USER_ERROR:
          return "E_USER_ERROR";
      case E_USER_WARNING:
          return "E_USER_WARNING";
      case E_USER_NOTICE:
          return "E_USER_NOTICE";
      case E_ALL:
          return "E_ALL";
      case E_STRICT:
          return "E_STRICT";
      case E_RECOVERABLE_ERROR:
          return "E_RECOVERABLE_ERROR";
      case E_DEPRECATED:
          return "E_DEPRECATED";
/*
      case E_USER_DEPRECATED:
          return "E_USER_DEPRECATED";
*/
      default:
          return "Unknown error type";
  }
}

function getTraceMessage(array $trace, $filename) {
    global $isLocal;
    $result = "";

    foreach ($trace as $traceline) {
        $result .= "at ";
        if (!isset($traceline["file"]) || empty($traceline["file"])) {
            $result .= $filename;
        } else {
            $result .= getLocation($traceline["file"]);
        }
        $result .= ":";
        if (isset($traceline["line"])) {
          $result .= $traceline["line"];
        } else {
          $result .= " ";
        }
        $result .= "\n";
        if (empty($traceline["file"])) {
          break;
        }
    }
    return $result;
}

function myExceptionHandler($e) {
  print("EXCEPTION: " . $e->getMessage() . "\n" . getTraceMessage($e->getTrace(), getLocation($e->getFile())));
  flush();
}

function myErrorHandler_DirectReport($errno, $errstr, $errfile, $errline) {
    if (!($errno & error_reporting())) {
        return FALSE;
    }

    if (version_compare(PHP_VERSION, '5.2.5', '>=')) {
        $trace = debug_backtrace(FALSE);
    } else {
        $trace = debug_backtrace();
    }

    array_shift($trace);

    foreach ($trace as $frame) {
        if ($frame['function'] == '__toString') {
            return FALSE;
        }
    }
    $errstr = getErrorMessage($errno) . ": " .
                    $errstr;

    print($errstr . "\n" . getTraceMessage($trace, getLocation($errfile)));
}

set_exception_handler('myExceptionHandler');
set_error_handler('myErrorHandler_DirectReport');
$my = error_reporting() & (~(E_ERROR | E_PARSE | E_CORE_ERROR | E_CORE_WARNING | E_COMPILE_ERROR | E_COMPILE_WARNING | E_STRICT));
error_reporting($my);
register_shutdown_function('myFatalErrorHandler');

require_once 'PHPUnit/Framework.php';
require_once 'PHPUnit/TextUI/TestRunner.php';

require_once 'PHPUnit/Framework/TestResult.php';
require_once 'PHPUnit/Framework/TestListener.php';
require_once 'PHPUnit/Framework/Warning.php';

require_once 'PHPUnit/Runner/StandardTestSuiteLoader.php';
require_once 'PHPUnit/Runner/IncludePathTestCollector.php';

require_once 'PHPUnit/Util/Filter.php';
$global_phpunit_request_start = false;

$config_file = "";
$system_delimiter = "\\";
// mappings have system independent slashes
$serverToClientMappings = array();
$isLocal = true;

function escape($text) {
    $text = str_replace("|", "||", $text);
    $text = str_replace("'", "|'", $text);
    $text = str_replace("\n", "|n", $text);
    $text = str_replace("\r", "|r", $text);
    $text = str_replace("]", "|]", $text);

    return $text;
}

function traceCommand($command, $param1Name, $param1Value,
$param2Name = null, $param2Value = null,
$param3Name = null, $param3Value = null) {
    $line = "\n##teamcity[" . $command . " " . $param1Name . "='" . escape($param1Value) . "'";
    if ($param2Name != null) {
        $line = $line . " " . $param2Name . "='" . escape($param2Value) . "'";
    }
    if ($param3Name != null) {
        $line = $line . " " . $param3Name . "='" . escape($param3Value) . "'";
    }

    $line = $line . "]\n";
    return $line;
}

function myErrorHandler_ConvertToException($errno, $errstr, $errfile, $errline) {
    if (!($errno & error_reporting())) {
        return FALSE;
    }

    if (version_compare(PHP_VERSION, '5.2.5', '>=')) {
        $trace = debug_backtrace(FALSE);
    } else {
        $trace = debug_backtrace();
    }

    array_shift($trace);

    foreach ($trace as $frame) {
        if ($frame['function'] == '__toString') {
            return FALSE;
        }
    }

    if ($errno == E_NOTICE || $errno == E_STRICT) {
        if (PHPUnit_Framework_Error_Notice::$enabled !== TRUE) {
            return FALSE;
        }

        $exception = 'PHPUnit_Framework_Error_Notice';
    }

    else if ($errno == E_WARNING) {
        if (PHPUnit_Framework_Error_Warning::$enabled !== TRUE) {
            return FALSE;
        }

        $exception = 'PHPUnit_Framework_Error_Warning';
    }

    else {
        $exception = 'PHPUnit_Framework_Error';
    }

    $errstr = getErrorMessage($errno) . ": " .
                    $errstr . "\n at " . getLocation($errfile) . ":" . $errline . "\n";

    throw new $exception($errstr, $errno, $errfile, $errline, $trace);
}

function myFatalErrorHandler() {
  global $global_phpunit_request_start;
  global $isLocal;
  if (isset($global_phpunit_request_start) && $global_phpunit_request_start) {
    print("PHPUnit is not configured properly");
    flush();
    die();
  }
  $last_error = error_get_last();
  if (!empty($last_error)) {
      print(getErrorMessage($last_error['type']) . ": " .
                    $last_error['message'] . "\n at " . $last_error['file'] . ":" . $last_error['line'] . "\n");
  }
}

class SimpleTestListener extends PHPUnit_Util_Printer implements PHPUnit_Framework_TestListener {
    var $LOCATION_PROTOCOL;

    var $myfilename;

    var $depth;

    public function __construct($filename = ""){
        $this->LOCATION_PROTOCOL = "php_qn://";
        $this->myfilename = getLocation(realpath((string)$filename));
        $this->depth = 0;
    }

    public function flush(){
    }

    public function incrementalFlush(){
    }

    public function write($buffer){
    }

    public function getAutoFlush(){
        return $this->autoFlush;
    }

    public function setAutoFlush($autoFlush){
    }

    public function addError(PHPUnit_Framework_Test $test, Exception $e, $time) {
        $message = $e->getMessage();
        print(traceCommand("testFailed", "name", $test->getName(), "message", $message/*$e->getMessage()*/,
            "details", getTraceMessage($e->getTrace(), $this->myfilename)));
        flush();
    }

    public function addFailure(PHPUnit_Framework_Test $test, PHPUnit_Framework_AssertionFailedError $e, $time) {
        if ($test instanceof PHPUnit_Framework_Warning) {
            return;
        }
        $message = $e->getMessage();
        print(traceCommand("testFailed", "name", $test->getName(), "message", $message,
            "details", /*getPrettyTrace($e->getTraceAsString())*/ getTraceMessage($e->getTrace(), $this->myfilename)));
        flush();
    }

    public function addIncompleteTest(PHPUnit_Framework_Test $test, Exception $e, $time) {
        if (!is_null($e)) {
            print(traceCommand("testIgnored", "name", $test->getName(), "message", $e->getMessage(),
                "details", getTraceMessage($e->getTrace(), $this->myfilename)/*,
                "locationHint", "php_qn://" . $this->myfilename . "::" . $test->toString()*/));
        } else {
            print(traceCommand("testIgnored", "name", $test->getName(), "message", ""));
        }
        // print(traceCommand("testIgnored", "name", $test->getName()));
        flush();
    }

    public function addSkippedTest(PHPUnit_Framework_Test $test, Exception $e, $time) {
        print(traceCommand("testStarted", "name", $test->getName(), "locationHint", "php_qn://" . $this->myfilename. "::" . $test->toString()));
        print(traceCommand("testIgnored", "name", $test->getName(), "message", $e->getMessage()));
        print(traceCommand("testFinished", "name", $test->getName(), "duration", 0));
        flush();
    }

    public function startTest(PHPUnit_Framework_Test $test) {
        if ($test instanceof PHPUnit_Framework_Warning) {
            $pieces = explode('"', $test->getMessage());
            if (count($pieces) == 3) {
                $testName = $pieces[1];
                $shownTestName = "Warning (" . $testName . ")";

                print(traceCommand("testStarted", "name", $shownTestName, "locationHint", "php_qn://" . $this->myfilename. "::::" . $testName));
                print(traceCommand("testIgnored", "name", $shownTestName, "message", $test->getMessage()));
                print(traceCommand("testFinished", "name", $shownTestName, "duration", 0));
                return;
            }
        }
        print(traceCommand("testStarted", "name", $test->getName(), "locationHint", "php_qn://" . $this->myfilename. "::" . $test->toString()));
        flush();
    }

    public function endTest(PHPUnit_Framework_Test $test, $time) {
        print(traceCommand("testFinished", "name", $test->getName(), "duration", (int)(round($time, 2) * 1000) ));
        flush();
    }

    public function startTestSuite(PHPUnit_Framework_TestSuite $suite) {
        $this->depth++;
        if ($this->depth >= 2) {
            return;
        }
        $location = $this->LOCATION_PROTOCOL . $this->myfilename . "::" . $suite->toString();
        print(traceCommand("testSuiteStarted", "name", $suite->getName() . " (" . basename($this->myfilename) . ")",
        "locationHint", $location));
        flush();
    }

    public function endTestSuite(PHPUnit_Framework_TestSuite $suite) {
        $this->depth--;
        if ($this->depth >= 1) {
            return;
        }
        print(traceCommand("testSuiteFinished", "name", $suite->getName() . " (" . basename($this->myfilename) . ")"));
        flush();
    }
}

class MyTestRunner {
    private static function runTest(PHPUnit_Framework_TestSuite $test, $filename, $arguments) {
        set_exception_handler(null);
        try {
            if (isset($arguments['loader'])) {
                $runner = new PHPUnit_TextUI_TestRunner($arguments['loader']);
            } else {
                $runner = new PHPUnit_TextUI_TestRunner();
            }
            $arguments['printer'] = new SimpleTestListener($filename);
            $result = $runner->doRun($test, $arguments);
        } catch(Exception $e) {
            myExceptionHandler($e);
        }
        restore_exception_handler();
    }

    public static function collectTestsFromFile($filename) {
        PHPUnit_Util_Class::collectStart();
        PHPUnit_Util_Fileloader::checkAndLoad($filename, FALSE);
        $newClasses = PHPUnit_Util_Class::collectEnd();
        $baseName   = str_replace('.php', '', basename($filename));

        foreach ($newClasses as $className) {
            if (substr($className, 0 - strlen($baseName)) == $baseName) {
                $newClasses = array($className);
                break;
            }
        }
        $tests = array();
            // of PHPUnit_Framework_Test
        foreach ($newClasses as $className) {
            $class = new ReflectionClass($className);

            if (!$class->isAbstract()) {
                if ($class->hasMethod(PHPUnit_Runner_BaseTestRunner::SUITE_METHODNAME)) {
                    $method = $class->getMethod(
                            PHPUnit_Runner_BaseTestRunner::SUITE_METHODNAME
                            );

                    if ($method->isStatic()) {
                        $newTest = $method->invoke(NULL, $className);
                            // of type PHPUnit_Framework_Test
                        $tests[] = $newTest;
                    }
                }

                else if ($class->implementsInterface('PHPUnit_Framework_Test')) {
                    $tests[] = new PHPUnit_Framework_TestSuite($class);
                }
            }
        }
        return $tests;
    }

    public static function main() {
      global $isLocal;
        // check number of arguments
        $isLocal = !isset($_SERVER['HTTP_USER_AGENT']);
        $arguments = array(
            'listGroups'              => FALSE,
            'loader'                  => NULL,
            'useDefaultConfiguration' => TRUE
        );

        $loader = NULL;
        $startPos = 1;
        $canCountTest = true;
        global $config_file;
        if (($isLocal && $_SERVER['argv'][1] == "-config") ||
            (!$isLocal && strcmp($config_file, "") != 0 && strcmp($config_file, "/*config_xml*/") != 0)) {
            // check if configuration specified
            $canCountTest = false;
            $path = $isLocal ? $_SERVER['argv'][2] : $config_file;//$_GET["config_xml"];
            $arguments['configuration'] = $path;
            $startPos = 3;
            $configuration = PHPUnit_Util_Configuration::getInstance($path);
            $phpunit = $configuration->getPHPUnitConfiguration();

            if (isset($phpunit['testSuiteLoaderClass'])) {
                if (isset($phpunit['testSuiteLoaderFile'])) {
                    $file = $phpunit['testSuiteLoaderFile'];
                } else {
                    $file = '';
                }

                $command = new PHPUnit_TextUI_Command;
                $loader = $command->handleLoader($phpunit['testSuiteLoaderClass'], $file);
                $arguments['loader'] = $loader;
            }

            $configuration->handlePHPConfiguration();

            $phpunitConfiguration = $configuration->getPHPUnitConfiguration();

            if (isset($phpunitConfiguration['bootstrap'])) {
                PHPUnit_Util_Fileloader::load($phpunitConfiguration['bootstrap']);
            }

            $browsers = $configuration->getSeleniumBrowserConfiguration();

            if (!empty($browsers)) {
                require_once 'PHPUnit/Extensions/SeleniumTestCase.php';
                PHPUnit_Extensions_SeleniumTestCase::$browsers = $browsers;
            }

        }

        if (($isLocal && $_SERVER['argv'][$startPos] == "-group") || (!$isLocal && isset($_GET["groups"]))) {
            $arguments['groups'] = explode(',', $isLocal ? $_SERVER['argv'][$startPos + 1] : $_GET["groups"]);
            $startPos += 2;
        }
        if (($isLocal && $_SERVER['argv'][$startPos] == "-exclude-group") || (!$isLocal && isset($_GET["exclude_groups"]))) {
            $arguments['excludeGroups'] = explode(',', $isLocal ? $_SERVER['argv'][$startPos + 1] : $_GET["exclude_groups"]);
            $startPos += 2;
        }

        $check = $isLocal ? $_SERVER['argv'][$startPos] : $_GET["mode"];


        if ($check == "c") {
            $suiteClassName = $isLocal ? $_SERVER['argv'][$startPos + 1] : $_GET["class"];
            $suiteClassFile = $isLocal ? $_SERVER['argv'][$startPos + 2] : $_GET["file"];
            try {
                // $testClass = ();

                if ($loader == NULL) {
                    $loader = new PHPUnit_Runner_StandardTestSuiteLoader;
                }
                $testClass = $loader->load($suiteClassName, $suiteClassFile, FALSE);
            } catch (Exception $e) {
                myExceptionHandler($e);
                return;
            }
            try {
                // if class is a suite
                $suiteMethod = $testClass->getMethod('suite');

                if ($suiteMethod->isAbstract() ||
                        !$suiteMethod->isPublic() ||
                        !$suiteMethod->isStatic()) {
                    return;
                }

                try {
                    // ?? suite does not have testName argument
                    $test = $suiteMethod->invoke(NULL, $testClass->getName());
                    $test->setName($suiteClassName);
                    if ($canCountTest) {
                        print(traceCommand("testCount", "count", (string)sizeof($test)));
                    }
                    self::runTest($test, $suiteClassFile, $arguments);
                } catch (ReflectionException $e) {
                    myExceptionHandler($e);
                    return;
                }
            } catch (ReflectionException $e) {
                $test = new PHPUnit_Framework_TestSuite($testClass);
                if ($canCountTest) {
                    print(traceCommand("testCount", "count", (string)sizeof($test)));
                }
                self::runTest($test, $suiteClassFile, $arguments);
            }
        } else if ($check == "d") {
            // if run directory
            // in remote case we put this script in the test directory
            $suiteDirName = $isLocal ? $_SERVER['argv'][$startPos + 1] : dirname(__FILE__);
            if (is_dir($suiteDirName) && !is_file($suiteDirName . '.php')) {
                $testCollector = new PHPUnit_Runner_IncludePathTestCollector(array($suiteDirName));

                    // $test = new PHPUnit_Framework_TestSuite($suiteDirName);
                $filenames = $testCollector->collectTests();
                $number = 0;
                $alltests = array();
                foreach ($filenames as $filename) {
                    $tests = self::collectTestsFromFile($filename);

                    foreach($tests as $currenttest) {
                        $number += sizeof($currenttest);
                        $alltests[] = $currenttest;
                        $alltests[] = $filename;
                    }
                }
                if ($canCountTest) {
                    print(traceCommand("testCount", "count", (string)$number));
                }
                for ($i = 0; $i < count($alltests); $i += 2) {
                    self::runTest($alltests[$i], $alltests[$i + 1], $arguments);
                }
                return;
            }
        } else if ($check == 'f') {
            // if run all in file
            $filename = $isLocal ? $_SERVER['argv'][$startPos + 1] : $_GET["file"];
            $tests = self::collectTestsFromFile($filename);

            $test = new PHPUnit_Framework_TestSuite();
            $number = 0;
            foreach($tests as $currenttest) {
                if ($tests) {
                    $test->addTest($currenttest);
                    $number += sizeof($currenttest);
                }
            }
            if ($canCountTest) {
                print(traceCommand("testCount", "count", $number));
            }

            foreach($tests as $currentTest) {
                self::runTest($currentTest, $filename, $arguments);
            }
            return;
        } else if ($check == 'm') {
            $suiteMethodName = $isLocal ? $_SERVER['argv'][$startPos + 1] : $_GET["method"];
            $suiteClassName = $isLocal ? $_SERVER['argv'][$startPos + 2] : $_GET["class"];
            $suiteClassFile = $isLocal ? $_SERVER['argv'][$startPos + 3] : $_GET["file"];
            try {
                $testClass = (new PHPUnit_Runner_StandardTestSuiteLoader);
                $testClass = $testClass->load($suiteClassName, $suiteClassFile, FALSE);
            } catch (Exception $e) {
                myExceptionHandler($e);
                return;
            }
            try {
                // if class is a suite
                $suiteMethod = $testClass->getMethod($suiteMethodName);

                if ($suiteMethodName == 'suite') {
                    if (($suiteMethod->isAbstract() ||
                            !$suiteMethod->isPublic() ||
                            !$suiteMethod->isStatic())) {
                        return;
                    }

                    try {
                        $test = $suiteMethod->invoke(NULL, $testClass->getName());

                        $test->setName($suiteClassName);
                        if ($canCountTest) {
                            print(traceCommand("testCount", "count", (string)sizeof($test)));
                        }
                        self::runTest($test , $suiteClassFile, $arguments);
                    } catch (ReflectionException $e) {
                        myExceptionHandler($e);
                        return;
                    }
                } else {
                    $test = PHPUnit_Framework_TestSuite::createTest($testClass, $suiteMethodName);
                    $testSuite = new PHPUnit_Framework_TestSuite();
                    $testSuite->addTest($test);
                    $testSuite->setName($suiteClassName);
                    if ($canCountTest) {
                        print(traceCommand("testCount", "count", (string)sizeof($test)));
                    }
                    self::runTest($testSuite, $suiteClassFile, $arguments);
                }

            } catch (ReflectionException $e) {
                myExceptionHandler($e);
                return;
            }
        }
        else if ($check == 'x') {
            $testSuite = $configuration->getTestSuiteConfiguration();
            self::runTest($testSuite, "", $arguments);
        }
    }
}

PHPUnit_Util_Filter::addFileToFilter(__FILE__, 'PHPUNIT');

try {
    MyTestRunner::main();
} catch(Exception $e) {
  myExceptionHandler($e);
}

restore_error_handler();
restore_exception_handler();
?>
