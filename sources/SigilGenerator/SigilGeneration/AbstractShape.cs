using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using SkiaSharp;

namespace SigilGenerator.SigilGeneration; 

public abstract class AbstractShape {
    protected float Size { get; private set; }
    protected Vector2 Normal { get; private set; }
    
    protected Vector2 Position { get; private set; }

    protected readonly List<AbstractShape> Children = new List<AbstractShape>();

    public void RootSetUp() {
        this.SetUp(null, -1);
    }
    private void SetUp(AbstractShape? parent, int number) {
        if (parent == null) {
            Size = DrawConfig.StartSize;
            Normal = DrawConfig.StartNormal;
            Position = DrawConfig.StartPosition;
            return;
        }

        Size = parent.GetSize(number);
        Normal = parent.GetNormal(number);
        Position = parent.GetPosition(number);
    }
    
    public abstract void DrawSelf(SKCanvas canvas, uint color);

    public void TrySetChild(AbstractShape child) {
        try {
            var childNumber = SetChild(child);
            if (childNumber != -1)
                if (HasIndex(childNumber))
                    child.SetUp(this, childNumber);
        }
        catch (Exception) {
            throw new Exception();
        }

    }
    public abstract float GetSize(int child);
    public abstract Vector2 GetNormal(int child);
    public abstract Vector2 GetPosition(int child);

    protected virtual int SetChild(AbstractShape child) {
        
            var result = Children.Count;
            if (HasIndex(result)) {
                Children.Add(child);
                return result;
            }

            if (result == 0) return -1;
            AbstractShape nr1;
            var children_ = Children.Skip(NaturalShift()).ToList();
            children_.Sort((x, y) => x.Children.Count - y.Children.Count);
            try { nr1 = children_.First(x => x.HasIndex(x.Children.Count)); }
            catch (InvalidOperationException) {
                nr1 = children_.First(x => x.Children.Count(t => t.HasIndex(0)) > 0);
            }

            nr1?.TrySetChild(child);

            return result;
        

        return -1;
    }

    public abstract bool HasIndex(int index);
    public virtual int NaturalShift() => 0;
}