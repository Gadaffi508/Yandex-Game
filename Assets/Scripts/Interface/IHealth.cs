namespace Ducktastic
{
    interface IHealth
    {
        public int Health { get; set; }

        void TakeDamage(int damage);

        void Explode();
    }
}
