using System;

public struct ComplexNumber 
{
    private readonly double _real;
    private readonly double _imaginary;
    public ComplexNumber(double real, double imaginary)
    {
        _real = real;
        _imaginary = imaginary;
    }
    public ComplexNumber(double real)
    {
        _real = real;
        _imaginary = 0;
    }

    public double Real() => _real;

    public double Imaginary() => _imaginary;

    public ComplexNumber Mul(ComplexNumber other)
    {
        var real = _real * other._real + _imaginary * other._imaginary * -1;
        var imaginary = _real * other._imaginary + _imaginary * other._real;
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(_real + other._real, _imaginary + other._imaginary);
    }

    public ComplexNumber Sub(ComplexNumber other)
    {
        return new ComplexNumber(_real - other._real, _imaginary - other._imaginary);
    }

    public ComplexNumber Div(ComplexNumber other)
    {
        //(a + i * b) / (c + i * d) = (a * c + b * d)/(c^2 + d^2) + (b * c - a * d)/(c^2 + d^2) * i
        var real = (_real * other._real + _imaginary * other._imaginary) /
                   (Math.Pow(other._real, 2) + Math.Pow(other._imaginary, 2));
        var imaginary = (_imaginary * other._real - _real * other._imaginary) /
                        (Math.Pow(other._real, 2) + Math.Pow(other._imaginary, 2));

        return new ComplexNumber(real, imaginary);
    }

    public double Abs()
    {
        return Math.Sqrt(Math.Pow(_real, 2) + Math.Pow(_imaginary, 2));
    }

    public ComplexNumber Conjugate()
    {
        return new ComplexNumber(_real, -_imaginary);
        // //1 / (a + i * b) = a/(a^2 + b^2) - b/(a^2 + b^2) * i
        // var real = _real / (Math.Pow(_real, 2) + Math.Pow(_imaginary, 2));
        // var imaginary = _imaginary / (Math.Pow(_real, 2) + Math.Pow(_imaginary, 2));
        // return new ComplexNumber(real, -imaginary);
    }
    
    public ComplexNumber Exp()
    {
        //^(a + i * b) = e^a * e^(i * b), the last term of which is given by Euler's formula e^(i * b) = cos(b) + i * sin(b).
        var real = Math.Exp(_real) * Math.Cos(_imaginary);
        var imaginary = Math.Exp(_real) * Math.Sin(_imaginary);
        return new ComplexNumber(real, imaginary);
    }

    public ComplexNumber Add(int other)
    {
        return new ComplexNumber(_real + other, _imaginary);
    }
    public ComplexNumber Sub(int other)
    {
        return new ComplexNumber(_real - other, _imaginary);
    }
    public ComplexNumber Mul(int other)
    {
        return new ComplexNumber(_real * other, _imaginary * other);
    }
    public ComplexNumber Div(int other)
    {
        return new ComplexNumber(_real / other, _imaginary / other);
    }
}