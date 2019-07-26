antlr4 -Dlanguage=Java -o .java FilterExpressionDsl.g4 -no-listener -visitor ^
&& pushd .java ^
&& javac *.java ^
&& grun FilterExpressionDsl expr -gui