using UnityEngine;
using System.Collections.Generic;

public class LineSegment {

  public Vector2 P1;
  public Vector2 P2;
  private List<float> ordered_xs;

  public LineSegment(Vector2 P1, Vector2 P2) {
    this.P1 = P1;
    this.P2 = P2;
    this.ordered_xs = new List<float> { P1.x, P2.x };
    this.ordered_xs.Sort();
  }

  // bleh https://blog.dakwamine.fr/?p=1943
  public bool intersects(LineSegment other) {
    float tmp = (other.P2.x - other.P1.x) * (this.P2.y - this.P1.y) - (other.P2.y - other.P1.y) * (this.P2.x - this.P1.x);
 
    if (tmp == 0) {
      // No solution!
      return false;
    }
 
    float mu = ((this.P1.x - other.P1.x) * (this.P2.y - this.P1.y) - (this.P1.y - other.P1.y) * (this.P2.x - this.P1.x)) / tmp;
    float int_x = other.P1.x + (other.P2.x - other.P1.x) * mu;

    // return new Vector2(
    //     B1.x + (B2.x - B1.x) * mu,
    //     B1.y + (B2.y - B1.y) * mu
    // );

    return int_x >= this.ordered_xs[0] && int_x <= this.ordered_xs[1];
  }
}