namespace N
module calculator = 

    let explode (s:string) = [for c in s -> c]

    let implode (xs:char list) =
        let sb = System.Text.StringBuilder(xs.Length)
        xs |> List.iter (sb.Append >> ignore)
        sb.ToString()

    let (|StartsWith|_|) (p : string) (s : string) =
       if s.StartsWith(p) then Some(s.Substring(p.Length)) else None

    let alphabet = "I,V,X,L,C,D,M".Split(',')

    let alphabetDict = alphabet |> Seq.mapi (fun i d -> d,i) |> dict

    exception InvalidRomanNumeralException of string

    // M=1000,D=500,C=100,L=50,X=10,V=5,I=1
    let rec parse = function
        | "" -> ""
        | StartsWith "M"  rest -> "M" + (parse rest)        // 1000
        | StartsWith "CM" rest -> "DCCCC" + (parse rest)    // 900
        | StartsWith "D"  rest -> "D" + (parse rest)        // 500
        | StartsWith "CD" rest -> "CCCC" + (parse rest)     // 400
        | StartsWith "C"  rest -> "C" + (parse rest)        // 100
        | StartsWith "XC" rest -> "LXXXX" + (parse rest)    // 90
        | StartsWith "L"  rest -> "L" + (parse rest)        // 50
        | StartsWith "XL" rest -> "XXXX" + (parse rest)     // 40
        | StartsWith "X"  rest -> "X" + (parse rest)        // 10
        | StartsWith "IX" rest -> "VIIII" + (parse rest)    // 9
        | StartsWith "V"  rest -> "V" + (parse rest)        // 5
        | StartsWith "IV" rest -> "IIII" + (parse rest)     // 4
        | StartsWith "I"  rest -> "I" + (parse rest)        // 1
        | _ -> raise (InvalidRomanNumeralException("invalid roman numeral")) 

    // order = -1 means smallest romans first
    // order =  1 means largest  romans first
    let sortStr str (order : int) (dict : System.Collections.Generic.IDictionary<string,int>) = 
        explode str |> List.sortBy (fun c -> order * dict.[c.ToString()]) |> implode

    let add (num1 : string) (num2 : string) = 
        num1 + num2

namespace NTEST   
module calculatorTest =

    open NUnit.Framework
    open FsUnit
    open N.calculator

    let sortDesc = -1
 
    [<Test>]   
    let `` add I + I should be II `` () =
       add "I" "I" |> should equal "II"
 
    [<Test>]
    let `` parse II should be II `` () =
        parse "II" |> should equal "II"

    [<Test>]
    let `` parse XL should be XXXX `` () =
        parse "XL" |> should equal "XXXX"

    [<Test>]
    let `` parse XLQ should be invalid `` () =
        ( fun() -> parse "XLQ" |> ignore) |> should throw typeof<N.calculator.InvalidRomanNumeralException>

    [<Test; ExpectedException(typeof<N.calculator.InvalidRomanNumeralException>)>]
    let `` parse XLJ should be invalid `` () =
        parse "XLJ" |> ignore 
               
    [<Test>]
    let `` sortStr IVX should be XVI `` () =
        sortStr "IVX" -1 alphabetDict |> should equal "XVI"

    [<Test>]
    let `` sortStr CCCLXVIIIIDCCCXXXXV should be DCCCCCCLXXXXXVVIIII `` () =
        sortStr "CCCLXVIIIIDCCCXXXXV" sortDesc alphabetDict |> should equal "DCCCCCCLXXXXXVVIIII"

    [<Test>]
    let `` add IV and IV should be IIIIIIII `` () =
        add (parse "IV") (parse "IV") |> should equal "IIIIIIII"

    [<Test>]
    let `` sortStr and add XIV and XIV should be XXIIIIIIII `` () =
        sortStr (add (parse "XIV") (parse "XIV")) sortDesc alphabetDict |> should equal "XXIIIIIIII"