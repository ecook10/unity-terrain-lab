using UnityEngine;
using SplineEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ContourFilter", menuName = "ScriptableObjects/ContourFilter", order = 2)]
public class ContourFilter : HeightFilter {

  public ContourSplines contourSplines;

  public override float getHeight(float x, float y) {
    return getHeight(new Vector2(x, y));
  }

  private Vector2 getPosition(SplinePoint p) {
    return new Vector2(p.Position.x, p.Position.y);
  }

  private float getHeight(Vector2 position) {
    List<ContourPointComp> allContourPoints = new List<ContourPointComp>();
    foreach (var s in contourSplines.splines) {
      foreach (var p in s.Points) {
        Vector2 point = getPosition(p);
        allContourPoints.Add(new ContourPointComp(s, point, Vector2.Distance(point, position)));
      }
    }
    allContourPoints.Sort((x, y) => x.Distance.CompareTo(y.Distance));
    Vector2 closestPoint = allContourPoints[0].Point;

    // List<(float Distance, BezierSpline Spline)> allPointDistances = new List();
    // for (var p in contourPoints) {
    //   allPointDistances.Add((Vector2.Distance(p.Point, position), p.Spline));
    // }
    // (float Distance, BezierSpline Spline) 
    // splines.splines.
    return 0;
  }

  private BezierSpline findEnclosingSpline(
    Vector2 position,
    BezierSpline closestSpline,
    Vector2 closestPoint
  ) {
    List<(LineSegment Segment, BezierSpline Spline)> otherSplineSegments = new List<(LineSegment, BezierSpline)>();
    foreach (var s in this.contourSplines.splines) {
      if (s == closestSpline) { continue; }
      for (var i = 0; i <= s.Points.Count; i++) {
        if (i == s.Points.Count) {
          otherSplineSegments.Add((new LineSegment(getPosition(s.Points[i]), getPosition(s.Points[0])), s));
        } else {
          otherSplineSegments.Add((new LineSegment(getPosition(s.Points[i]), getPosition(s.Points[i+1])), s));
        }
      }
    }
    int roamFactor = 0;
    BezierSpline enclosingSpline = default;
    while (enclosingSpline == default && roamFactor < 100) {
      roamFactor += 1;
      Vector2 roamEnd = position * 2 - closestPoint * roamFactor;
      LineSegment roamSegment = new LineSegment(position, roamEnd);
      (LineSegment Segment, BezierSpline Spline) result = otherSplineSegments.Find(s => s.Segment.intersects(roamSegment));
      if (!result.Equals(default)) enclosingSpline = result.Spline;
    }
    return closestSpline;
  }
}
