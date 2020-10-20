using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WindowMain.Model;

namespace WindowMain.View {
  public class CircularPanel:Panel {
	protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize) {
	  foreach(UIElement child in Children)
		child.Measure(new Size(double.PositiveInfinity,double.PositiveInfinity));

	  return base.MeasureOverride(availableSize);
	}

	// Arrange stuff in a circle
	protected override System.Windows.Size ArrangeOverride(System.Windows.Size finalSize) {
	  if(Children.Count > 0) {
		// Center & radius of panel
		Point center = new Point(finalSize.Width / 2.4,finalSize.Height / 2.4);
		//Point center = new Point(finalSize.Width / 2.2,finalSize.Height / 2.5);
		//Point center = new Point(finalSize.Width / 2,finalSize.Height / 2);
		double radius = Math.Min(finalSize.Width,finalSize.Height) / 2.0;
		//radius *= 0.7;   // To avoid hitting edges
		radius *= 0.5;   // To avoid hitting edges
						 //radius *= 0.3;   // To avoid hitting edges
						 //radius *= 1;   // To avoid hitting edges

		double TwoPI = 2.0 * Math.PI;

		// # radians between children
		double angleIncreaseRadians = TwoPI / Children.Count;

		double angleInRadians = 0.0;
		if(Children.Count==5) {
		  angleInRadians-=TwoPI/4+TwoPI/512;
		}

		if(Children.Count==4) {
		  angleInRadians-=TwoPI/8+TwoPI/4+TwoPI/256;
		}

		if(Children.Count==3) {
		  angleInRadians-=TwoPI/3-TwoPI/16-TwoPI/32+TwoPI/64-TwoPI/512;
		}

		foreach(UIElement child in Children) {
		  ModelHamburgerMenu mMenu = ((ContentPresenter)child).Content as ModelHamburgerMenu;
		  double angleTemp = angleInRadians+mMenu.DoubleAngleToSpin;
		  mMenu.DoubleAngleOnCircle=angleTemp;
		  Point childPosition = new Point(
						radius * Math.Cos(angleTemp) + center.X,
						radius * Math.Sin(angleTemp) + center.Y);

		  child.Arrange(new Rect(childPosition,child.DesiredSize));

		  angleInRadians += angleIncreaseRadians;
		}
	  }

	  return finalSize;
	}

  }
}
