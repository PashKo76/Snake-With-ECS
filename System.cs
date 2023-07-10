using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal class System
    {
        static public void UpdatePosition(Entity entitiesWithMovementComponend)
        {
            entitiesWithMovementComponend.position.X += entitiesWithMovementComponend.movement.Dx;
            entitiesWithMovementComponend.position.Y += entitiesWithMovementComponend.movement.Dy;
        }
        static public void UpdatePosition(IEnumerable<Entity> entitiesWithMovementComponend)
        {
            foreach(Entity e in entitiesWithMovementComponend)
            {
                UpdatePosition(e);
            }
        }
        static public void UpdateMovement(Entity entity, (int X, int Y) D)
        {
            if (D.X != 0 || D.Y != 0)
            {
                entity.movement.Dx = D.X;
                entity.movement.Dy = D.Y;
            }
        }
        static public void UpdateBuffer(Entity entity)
        {
            Render.SetIcon(entity.position.X, entity.position.Y, entity.visibility.Icon);
        }
        static public void UpdateBuffer(IEnumerable<Entity> entities)
        {
            foreach(Entity e in entities)
            {
                UpdateBuffer(e);
            }
        }
        static public bool CheckBorder(Entity entity)
        {
            return entity.position.X >= Render.Width - 1 || entity.position.X < 1 || entity.position.Y >= Render.Height - 1 || entity.position.Y < 1;
        }
        static public void CheckBorder(IEnumerable<Entity> entities)
        {
            foreach(Entity e in entities)
            {
                CheckBorder(e);
            }
        }
        static public bool UpdateCollision(Entity target, IEnumerable<Entity> trigers)
        {
            bool isCollision = false;
            foreach(Entity e in trigers)
            {
                isCollision |= e.position == target.position;
            }
            return isCollision;
        }
        static public bool UpdateCollision(Entity target, Entity triger)
        {
            return triger.position == target.position;
        }
        static public void MoveToRandom(Entity target)
        {
            target.position.X = Program.r.Next(1, Render.Width - 1);
            target.position.Y = Program.r.Next(1, Render.Height - 1);
        }
        static public void MoveToRandom(IEnumerable<Entity> targets)
        {
            foreach(Entity target in targets)
            {
                MoveToRandom(target);
            }
        }
    }
}
