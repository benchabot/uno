#if __IOS__
using UIKit;
using _View = UIKit.UIView;
#elif __MACOS__
using AppKit;
using _View = AppKit.NSView;
#elif __ANDROID__
using _View = Android.Views.ViewGroup;
#else
using _View = Windows.UI.Xaml.UIElement;
#endif

using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Uno.UI.Extensions
{
	public static partial class ViewExtensions
	{
		/// <summary>
		/// Get all ancestor views of <paramref name="view"/>, in order from its immediate parent to the root of the visual tree.
		/// </summary>
		public static IEnumerable<_View> GetVisualAncestry(this _View view)
		{
			var ancestor = view.GetVisualTreeParent();
			while (ancestor != null)
			{
				yield return ancestor;
				ancestor = ancestor.GetVisualTreeParent();
			}
		}

		internal static string GetElementSpecificDetails(this UIElement element)
		{
			return element switch
			{
				TextBlock textBlock => $" Text=\"{textBlock.Text}\" Foreground={textBlock.Foreground}",
				ScrollViewer scrollViewer => $" Extent={scrollViewer.ExtentWidth}x{scrollViewer.ExtentHeight} Offset={scrollViewer.ScrollOffsets}",
				Viewbox viewbox => $" Stretch={viewbox.Stretch}",
				_ => ""
			};
		}

		internal static string GetTransformDetails(this Transform transform)
		{
			string GetMatrix(MatrixTransform matrix)
			{
				var m = matrix.Matrix.Inner;
				return $" Matrix=[{m.M11}, {m.M21}, {m.M31}, {m.M12}, {m.M22}, {m.M32}]";
			}

			return transform switch
			{
				ScaleTransform scale => scale.ScaleX == 1d && scale.ScaleY == 1d ? " UNSCALED" : $" ScaleX/Y={scale.ScaleX}/{scale.ScaleY}",
				TranslateTransform translate => $" TranslateX/Y={translate.X}/{translate.Y}",
				TransformGroup group => " TransfrmGrp[" + group.Children.Select(GetTransformDetails).JoinBy(", ") + "]",
				RotateTransform rotate => $" Rotate={rotate.Angle}",
				MatrixTransform matrix => GetMatrix(matrix),
				CompositeTransform composite => $" ScaleX/Y={composite.ScaleX}/{composite.ScaleY} TranslateX/Y={composite.TranslateX}/{composite.TranslateY}",
				SkewTransform skew => $" SkewX={skew.AngleX}  SkewY={skew.AngleY}",
				_ => ""
			};
		}
	}
}
