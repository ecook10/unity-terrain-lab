using UnityEngine;
using SplineEditor;

public struct ContourPointComp {
  public BezierSpline Spline;
  public Vector2 Point;
  public float Distance;
  public ContourPointComp(BezierSpline Spline, Vector2 Point, float Distance) {
    this.Spline = Spline;
    this.Point = Point;
    this.Distance = Distance;
  }
}
